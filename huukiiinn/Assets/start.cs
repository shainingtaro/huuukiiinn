using UnityEngine;
using UnityEngine.SceneManagement; // ★ シーン管理に必須

public class SceneLoader : MonoBehaviour
{
    // 遷移先のシーン名をInspectorから設定できるようにする
    [SerializeField]
    private string nextSceneName = "GameScene"; // デフォルトの遷移先シーン名

    // ボタンのOnClickイベントから呼び出すためのパブリックメソッド
    public void LoadNextScene()
    {
        Debug.Log("次のシーン");
        // SceneManager.LoadScene()で指定した名前のシーンへ遷移
        SceneManager.LoadScene(nextSceneName);
    }

    // シーン名の代わりに、ビルド設定のインデックス（番号）で遷移したい場合はこちら
    /*
    public void LoadSceneByIndex(int index)
    {
        SceneManager.LoadScene(index);
    }
    */
}