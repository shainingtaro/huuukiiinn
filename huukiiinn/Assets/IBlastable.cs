using UnityEngine;
public interface IBlastable
{
    /// <summary>
    /// Blast を受け取る。呼び出し元は力の向きと基準力のみを渡す。
    /// 実装側で forceMultiplier や destroyDelay, pooling を処理する。
    /// </summary>
    /// <param name="direction">水平方向（ワールド空間）を向くベクトル。正規化されていることを期待。</param>
    /// <param name="baseForce">コントローラが決めた基準力。</param>
    void Blast(Vector3 direction, float baseForce);
}
