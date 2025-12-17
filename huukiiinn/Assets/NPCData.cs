using UnityEngine;

[CreateAssetMenu(menuName = "NPC/NPC Data")]
public class NPCData : ScriptableObject
{
    [Header("見た目")]
    public GameObject hairPrefab;
    public Sprite faceSprite; // 表情（UI or 板ポリ想定）

    [Header("モーション")]
    public RuntimeAnimatorController animator;

    [Header("手荷物（テーブル2つ分）")]
    public LuggageData[] tableALuggages;
    public LuggageData[] tableBLuggages;
}
