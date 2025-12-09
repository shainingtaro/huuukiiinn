using UnityEngine;

[CreateAssetMenu(menuName = "Appearance/3D/HairVariant")]
public class HairVariantSO : ScriptableObject
{
    public string id;
    public GameObject hairPrefab;          // そのままInstantiateしてソケットに差すのが安全
    public Material[] overrideMaterials;   // 髪専用マテリアル（任意）
    public Vector3 localPositionOffset;
    public Vector3 localEulerOffset;
    public Vector3 localScale = Vector3.one;

    private void OnValidate()
    {
        if (hairPrefab != null && hairPrefab.GetComponentInChildren<SkinnedMeshRenderer>() == null)
            Debug.LogWarning(name + ": hairPrefab に SkinnedMeshRenderer が無い可能性があります。");
    }
}
