using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class ClickableTarget : MonoBehaviour
{
    [Header("Judge")]
    [Tooltip("このタグと一致するなら Good と判定する。空欄なら常に Neutral")]
    public string goodTag = "Good";

    [Header("Blast (base)")]
    public float baseForce = 5f;      // コントローラ側の基準力ではなくここで基準を管理する最小実装
    public float upward = 1f;         // 上向きの追加力
    public bool useImpulse = true;    // AddForce をインパルスで与えるか

    [Header("Blast multipliers (judge result)")]
    public float goodMultiplier = 1.0f;   // Good のときの倍率
    public float badMultiplier = 0.4f;    // Bad のときの倍率
    public float neutralMultiplier = 0.7f;

    [Header("Destroy")]
    public float destroyDelay = 1.0f;         // 吹っ飛ばしてから消すまでの時間（秒）
    public bool disableColliderOnDestroy = true;
    public bool stopPhysicsBeforeDestroy = false; // true にすると消える前に物理を止める

    // 内部
    Rigidbody rb;
    Collider[] colliders;
    bool destroyStarted = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        colliders = GetComponentsInChildren<Collider>();
    }

    /// <summary>
    /// ClickInputController から呼ばれる主要 API（最小構成）
    /// </summary>
    public void OnClicked(ClickContext ctx)
    {
        if (destroyStarted) return; // 既に削除処理が走っている場合は無視

        // 判定（最小：タグ比較）
        JudgeResult result = JudgeByTag();

        // 吹っ飛ばし（画面中心より左なら左、中央含め右は右）
        ApplyBlast(ctx, result);

        // 削除/無効化コルーチン開始
        StartCoroutine(DestroyAfterDelay());
    }

    enum JudgeResult { Good, Bad, Neutral }

    JudgeResult JudgeByTag()
    {
        if (string.IsNullOrEmpty(goodTag)) return JudgeResult.Neutral;
        if (gameObject.CompareTag(goodTag)) return JudgeResult.Good;
        return JudgeResult.Bad;
    }

    void ApplyBlast(ClickContext ctx, JudgeResult judgeResult)
    {
        // 画面上でオブジェクトの中心点の X を取得して左右判定
        Vector3 screenPos = ctx.Camera.WorldToScreenPoint(transform.position);
        float centerX = Screen.width * 0.5f;
        bool isLeft = screenPos.x < centerX; // 中央は右扱い（要変更ならここを調整）

        Vector3 camRight = ctx.Camera.transform.right;
        Vector3 horizontalDir = isLeft ? -camRight : camRight;

        // multiplier を決める
        float multiplier = neutralMultiplier;
        if (judgeResult == JudgeResult.Good) multiplier = goodMultiplier;
        else if (judgeResult == JudgeResult.Bad) multiplier = badMultiplier;

        Vector3 finalForce = horizontalDir.normalized * baseForce * multiplier + Vector3.up * upward;

        if (useImpulse)
            rb.AddForce(finalForce, ForceMode.Impulse);
        else
            rb.AddForce(finalForce, ForceMode.Force);
    }

    IEnumerator DestroyAfterDelay()
    {
        destroyStarted = true;

        if (disableColliderOnDestroy)
        {
            // 少しだけ待って力が乗る時間を確保してからコライダーを無効化
            yield return new WaitForSeconds(0.05f);
            foreach (var c in colliders) if (c) c.enabled = false;
        }

        if (stopPhysicsBeforeDestroy)
        {
            rb.isKinematic = true;
        }

        yield return new WaitForSeconds(destroyDelay);

        Destroy(gameObject);
    }
}
