using UnityEngine;
using UnityEngine.SceneManagement; // Sceneを操作するために必要

public class ResultScreenManager : MonoBehaviour
{
    // タイトル画面のScene名をインスペクターで設定できるようにします
    [SerializeField]
    private string title = "TitleScene"; // 例: "TitleScene"

    // リトライ先のゲーム画面のScene名をインスペクターで設定できるようにします
    [SerializeField]
    private string MainScene = "GameScene"; // 例: "GameScene" (リトライでロードするScene)

    /// <summary>
    /// タイトル画面へ遷移します。
    /// </summary>
    public void OnClickTitleButton()
    {
        // 指定されたScene名に切り替えます
        SceneManager.LoadScene(title);
        Debug.Log("タイトル画面へ遷移します: " + title);
    }

    /// <summary>
    /// ゲームをリトライ（ゲーム画面を再ロード）します。
    /// </summary>
    public void OnClickRetryButton()
    {
        // 指定されたScene名に切り替えます
        SceneManager.LoadScene(MainScene);
        Debug.Log("ゲームをリトライします: " + MainScene);
    }

    /*
    // 補足: もしリザルト画面から現在のゲームシーンを再ロードしたい場合
    public void OnClickRetryCurrentScene()
    {
        // 現在のシーン名を取得して再ロードします
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    */
}