using UnityEngine;

public class NPCController : MonoBehaviour
{
    [Header("Attach Points")]
    public Transform hairRoot;
    public SpriteRenderer faceRenderer;
    public Transform tableASlot;
    public Transform tableBSlot;

    private GameObject hairInstance;

    public void Setup(NPCData data)
    {
        // 髪型
        if (hairInstance) Destroy(hairInstance);
        hairInstance = Instantiate(data.hairPrefab, hairRoot);

        // 表情
        faceRenderer.sprite = data.faceSprite;

        // モーション
        GetComponent<Animator>().runtimeAnimatorController = data.animator;

        // 手荷物配置
        SpawnLuggages(data.tableALuggages, tableASlot);
        SpawnLuggages(data.tableBLuggages, tableBSlot);
    }

    void SpawnLuggages(LuggageData[] luggages, Transform root)
    {
        foreach (Transform child in root)
            Destroy(child.gameObject);

        foreach (var luggage in luggages)
        {
            Instantiate(luggage.luggagePrefab, root);
        }
    }
}
