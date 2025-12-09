using UnityEngine;

[CreateAssetMenu(menuName = "Appearance/3D/MotionSet")]
public class MotionSetSO : ScriptableObject
{
    public string id;
    public RuntimeAnimatorController baseController;
    public AnimatorOverrideController overrideController; // óDêÊ
}
