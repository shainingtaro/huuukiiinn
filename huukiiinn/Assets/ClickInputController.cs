using UnityEngine;
using UnityEngine.EventSystems;

public struct ClickContext
{
    public Vector3 ScreenPosition;
    public Vector3 WorldHitPoint;
    public Ray Ray;
    public Camera Camera;
}

[RequireComponent(typeof(Camera))]
public class ClickInputController : MonoBehaviour
{
    public Camera targetCamera;            // 空なら Camera.main を使う
    public LayerMask clickableLayer = ~0;  // クリック対象レイヤー
    public float maxDistance = 50f;
    public bool ignoreUI = true;           // UI上のクリックを無視するか

    void Reset() => targetCamera = Camera.main;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            HandleClick(Input.mousePosition);
    }

    public void HandleClick(Vector3 screenPos)
    {
        if (ignoreUI && EventSystem.current != null && EventSystem.current.IsPointerOverGameObject()) return;
        if (targetCamera == null) targetCamera = Camera.main;

        Ray ray = targetCamera.ScreenPointToRay(screenPos);
        if (Physics.Raycast(ray, out RaycastHit hit, maxDistance, clickableLayer))
        {
            var target = hit.collider.GetComponentInParent<ClickableTarget>();
            if (target == null) return;

            ClickContext ctx = new ClickContext
            {
                ScreenPosition = screenPos,
                WorldHitPoint = hit.point,
                Ray = ray,
                Camera = targetCamera
            };

            target.OnClicked(ctx);
        }
    }
}
