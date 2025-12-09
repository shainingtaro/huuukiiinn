// IJudge.cs
using UnityEngine;

public enum JudgeResult { Good, Bad, Neutral } // 必要なら拡張可能

public interface IJudge
{
    // クリックされた時に判定を行う。target = クリックされた GameObject、
    // context に評価に必要な情報を渡せる（例: プレイヤー状態、クリック位置）。
    JudgeResult Judge(GameObject target, ClickContext context);
}
