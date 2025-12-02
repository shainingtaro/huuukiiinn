using UnityEngine;
using UnityEngine.SceneManagement;

public class option : MonoBehaviour
{
    // オプション画面のシーン名を設定（InspectorでTitleSceneから遷移）
    [SerializeField]
    private string optionsSceneName = "OptionsScene";

    // メインメニューのシーン名を設定（OptionsSceneから戻るため）
    [SerializeField]
    private string titleSceneName = "title";

    /// <summary>
    /// オプション画面へ遷移するメソッド
    /// </summary>
    public void LoadOptionsScene()
    {
        // SceneManager.LoadScene()でオプション画面へ遷移
        SceneManager.LoadScene(optionsSceneName);
    }

    /// <summary>
    /// メインメニュー画面へ戻るメソッド
    /// </summary>
    public void LoadMainScene()
    {
        // SceneManager.LoadScene()でメインメニュー画面へ戻る
        SceneManager.LoadScene(titleSceneName);
    }
}
