// SimpleObjectManager.cs
using System.Collections.Generic;
using UnityEngine;

public class DeskManager : MonoBehaviour
{
    [Header("登録するプレハブ（Inspector）")]
    public List<GameObject> prefabs = new List<GameObject>();

    [Header("管理対象（生成されたインスタンス）")]
    public List<GameObject> instances = new List<GameObject>();

    /// <summary> 指定 prefab を生成して管理リストに追加して返す </summary>
    public GameObject Spawn(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        if (prefab == null) return null;
        var go = Instantiate(prefab, position, rotation, transform);
        instances.Add(go);
        return go;
    }

    /// <summary> index で取得して消す（Destroy） </summary>
    public void DestroyInstance(int index)
    {
        if (index < 0 || index >= instances.Count) return;
        var go = instances[index];
        instances.RemoveAt(index);
        if (go != null) Destroy(go);
    }

    /// <summary> 全インスタンスを Destroy（管理リストクリア） </summary>
    public void DestroyAll()
    {
        foreach (var go in instances) if (go != null) Destroy(go);
        instances.Clear();
    }

    /// <summary> 生成済みインスタンスを一括で非表示に（SetActive(false)） </summary>
    public void DeactivateAll()
    {
        foreach (var go in instances) if (go != null) go.SetActive(false);
    }

    /// <summary> 生成済みインスタンスを一括で有効化（SetActive(true)） </summary>
    public void ActivateAll()
    {
        foreach (var go in instances) if (go != null) go.SetActive(true);
    }

    /// <summary> 現在の管理数（null は除外） </summary>
    public int ActiveCount()
    {
        int c = 0;
        foreach (var go in instances) if (go != null) c++;
        return c;
    }
}
