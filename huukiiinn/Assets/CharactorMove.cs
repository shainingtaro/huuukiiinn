using UnityEngine;

public class CharactorMove : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Transform target;

    private enum NPCState
    {
        LeftBack,
        Center,
        RightOut
    }

    private NPCState currentState = NPCState.LeftBack;

    public void Setup(
        Transform leftBack,
        Transform center,
        Transform rightOut
    )
    {
        currentState = NPCState.LeftBack;
        target = center;

        // ç∂âúÇ…ê∂ê¨
        transform.position = leftBack.position;
    }

    void Update()
    {
        if (target == null) return;

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            moveSpeed * Time.deltaTime
        );

        if (Vector3.Distance(transform.position, target.position) < 0.01f)
        {
            OnArrived();
        }
    }

    private void OnArrived()
    {
        switch (currentState)
        {
            case NPCState.LeftBack:
                currentState = NPCState.Center;
                target = center;
                break;

            case NPCState.Center:
                currentState = NPCState.RightOut;
                target = rightOut;
                break;

            case NPCState.RightOut:
                Destroy(gameObject); // âÊñ âEäOÇ≈çÌèú
                break;
        }
    }

    private Transform center;
    private Transform rightOut;
}
