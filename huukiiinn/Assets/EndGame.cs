using UnityEngine;

public class EndGame : MonoBehaviour
{
    // ゲームを終了させるためのパブリックメソッド
    public void QuitGame()
    {
        // 実行環境がUnityエディタの場合
#if UNITY_EDITOR
        // エディタでの実行を停止
        UnityEditor.EditorApplication.isPlaying = false;
#else
            // ビルドされたゲームを終了
            Application.Quit();
#endif

    }
}