using UnityEngine;

public class NPCVisualController : MonoBehaviour
{
    public Transform hairRoot;
    public SpriteRenderer faceRenderer;

    private GameObject currentHair;

    public void ApplyVisual(NPCData data)
    {
        if (currentHair != null)
            Destroy(currentHair);

        if (data.hairPrefab != null)
        {
            currentHair = Instantiate(
                data.hairPrefab,
                hairRoot
            );
        }

        faceRenderer.sprite = data.faceSprite;
    }
}
