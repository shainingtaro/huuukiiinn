using UnityEngine;

[CreateAssetMenu(menuName = "NPC/Luggage Data")]
public class LuggageData : ScriptableObject
{
    public GameObject luggagePrefab;
    public bool isDangerous; // 危険物かどうか（ゲーム判定用）
}
