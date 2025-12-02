using System.Collections.Generic;
using UnityEngine;

public class SimpleObjectManagerSO : MonoBehaviour
{
    [Header("データベース (ScriptableObject)")]
    public DeskManagement database;

    [Header("生成したオブジェクトの親")]
    public Transform parent; // 机の上の位置 (空オブジェクト) を指定

    private List<GameObject> instances = new List<GameObject>();

    private void Start()
    {
        if (database == null || database.Deskprefabs.Count == 0)
        {
            Debug.LogWarning("ObjectDatabaseSO が設定されていません");
            return;
        }

        // すべてインスタンス化（最初は非表示）
        foreach (var prefab in database.Deskprefabs)
        {
            if (prefab == null) continue;
            var obj = Instantiate(prefab, parent);
            obj.SetActive(false);
            instances.Add(obj);
        }
    }

    // 全部非表示
    public void HideAll()
    {
        foreach (var obj in instances)
        {
            if (obj != null) obj.SetActive(false);
        }
    }

    // 指定した番号のオブジェクトを表示
    public void ShowByIndex(int index)
    {
        if (index < 0 || index >= instances.Count)
        {
            Debug.LogWarning("ShowByIndex: インデックスが範囲外");
            return;
        }

        HideAll();
        instances[index].SetActive(true);
        Debug.Log(instances[index].name);
    }

    // 次のオブジェクトを表示（UIボタン用）
    private int currentIndex = -1;

    public void ShowNext()
    {
        if (instances.Count == 0) return;

        currentIndex++;
        if (currentIndex >= instances.Count)
        {
            currentIndex = 0;
        }

        ShowByIndex(currentIndex);
    }
}
