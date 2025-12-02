using UnityEngine;

public class NextButton : MonoBehaviour
{
    public DeskManager manager;

    private int currentIndex = -1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ShowNext()
    {
        if (manager == null || manager.instances.Count == 0)
        {
            Debug.LogWarning("Managerまたはインスタンスが空です");
            return;
        }

        // まず全て非表示
        manager.DeactivateAll();

        // 次のインデックスへ
        currentIndex++;
        if (currentIndex >= manager.instances.Count)
            currentIndex = 0; // ループさせたい場合

        // 対象のみ表示
        manager.instances[currentIndex].SetActive(true);

        Debug.Log("表示したオブジェクト: " + manager.instances[currentIndex].name);
    }

    public void HideAll()
    {
        manager.DeactivateAll();
        currentIndex = -1;
    }
}
