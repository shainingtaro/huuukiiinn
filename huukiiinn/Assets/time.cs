using UnityEngine;
using UnityEngine.SceneManagement; // シーン管理が必要な場合に使用

public class CountdownTimer : MonoBehaviour
{
    // デザイナーから設定できる制限時間（秒）
    public float timeLimit = 60f;

    // 現在の残り時間
    private float currentTime;

    // ゲームオーバー状態かどうか
    private bool isGameOver = false;

    void Start()
    {
        // ゲーム開始時に制限時間を設定
        currentTime = timeLimit;
        Debug.Log("カウントダウン開始！ 制限時間: " + timeLimit + "秒");
    }

    void Update()
    {
        // ゲームオーバーでなければ時間を減らす
        if (!isGameOver)
        {
            // 経過時間を減算
            currentTime -= Time.deltaTime;

            // 残り時間の表示 (実際のゲームではUIテキストに表示します)
            Debug.Log("残り時間: " + Mathf.Ceil(currentTime).ToString("F0"));

            // 時間がゼロ以下になったらゲームオーバー処理を実行
            if (currentTime <= 0)
            {
                currentTime = 0; // 念のため0に固定
                isGameOver = true;
                HandleGameOver();
            }
        }
    }

    // 時間切れになった時の処理
    void HandleGameOver()
    {
        Debug.Log(" タイムアップ！");

        // --- ここに時間切れ時の処理を記述します ---

        // 例: ゲームを一時停止する
        // Time.timeScale = 0f;

        // 例: 特定のゲームオーバーシーンをロードする (SceneManagementをusingに追加する必要があります)
        // SceneManager.LoadScene("GameOverScene");

        // 例: プレイヤーの動きを止める
        // GameObject.FindObjectOfType<PlayerController>().enabled = false;
    }

    // 外部から残り時間を取得するためのプロパティ (UI表示などに使用)
    public float GetCurrentTime()
    {
        return currentTime;
    }
}