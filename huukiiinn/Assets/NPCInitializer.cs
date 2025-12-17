using UnityEngine;

public class NPCInitializer : MonoBehaviour
{
    public NPCVisualController visual;
    public NPCLuggageController luggage;
    public Animator animator;

    public void Initialize(NPCData data)
    {
        // Œ©‚½–Ú
        visual.ApplyVisual(data);

        // ƒ‚[ƒVƒ‡ƒ“
        animator.runtimeAnimatorController = data.animator;

        // è‰×•¨
        luggage.Setup(data.tableALuggages, data.tableBLuggages);
    }
}
