using UnityEngine;

public class ClickBlastController : MonoBehaviour
{
    [Header("References")]
    public Camera targetCamera; // クリック用カメラ。空欄なら Camera.main を使う

    [Header("Settings")]
    public LayerMask clickableLayer = ~0; // クリック対象のレイヤー（デフォルト全部）
    public float horizontalForce = 5f;    // 左右に与える強さ（インパルス）
    public float upwardForce = 2f;        // 少し浮かせたい時の上向き成分
    public float randomAngleDeg = 10f;    // ランダムにブレを入れる（度）
    public bool useImpulse = true;        // AddForce の ForceMode をインパルスにするか

    void Reset()
    {
        targetCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            TryClickBlast(Input.mousePosition);
        }
    }

    void TryClickBlast(Vector3 mousePosition)
    {
        if (targetCamera == null) targetCamera = Camera.main;
        Ray ray = targetCamera.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, 100f, clickableLayer))
        {
            Rigidbody rb = hit.collider.attachedRigidbody;
            if (rb == null) return; // Rigidbody 必須

            // オブジェクトの画面位置を取得
            Vector3 screenPos = targetCamera.WorldToScreenPoint(hit.collider.bounds.center);
            float centerX = Screen.width * 0.5f;

            // 中央を含め右扱い： screenX >= center -> 右
            bool isLeft = screenPos.x < centerX;

            // カメラ座標系の右方向（ワールド空間）
            Vector3 camRight = targetCamera.transform.right;
            Vector3 horizontalDir = isLeft ? -camRight : camRight;

            // 少しランダム回転を入れて見栄え良くする
            float angle = Random.Range(-randomAngleDeg, randomAngleDeg);
            horizontalDir = Quaternion.AngleAxis(angle, targetCamera.transform.forward) * horizontalDir;

            // 最終力ベクトル（上向き成分をプラス）
            Vector3 force = horizontalDir.normalized * horizontalForce + Vector3.up * upwardForce;

            if (useImpulse)
                rb.AddForce(force, ForceMode.Impulse);
            else
                rb.AddForce(force, ForceMode.Force);
        }
    }
}
