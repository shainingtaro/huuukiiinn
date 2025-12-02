using UnityEngine;
using UnityEngine.Audio; // Audio Mixerを使うために必須
using UnityEngine.UI;   // UIのスライダーを扱うために必須

public class VolumeController : MonoBehaviour
{
    // 1. Inspectorから設定する Audio Mixer
    [SerializeField]
    private AudioMixer mixer;

    // 2. Audio Mixerで公開した音量パラメータの名前
    // ここで設定する文字列が、Audio Mixerで設定した「MasterVolume」と完全に一致している必要があります。
    [SerializeField]
    private string volumeParameter = "MasterVolume";

    // スライダーの値(0.0～1.0)をAudio Mixerが認識できるデシベル(dB)値に変換するための関数
    // AudioMixer.SetFloat()で設定する値はdBである必要があります。
    private float ConvertSliderValueToDecibel(float sliderValue)
    {
        // スライダーの値が0の時、音量を完全にミュート（-80dBが一般的）にします。
        if (sliderValue <= 0.0001f)
        {
            return -80f;
        }

        // スライダーの値（0.0～1.0）を対数スケールに変換します。
        // Mathf.Log10(sliderValue) * 20f; は、Audio Mixerへの一般的な変換式です。
        return Mathf.Log10(sliderValue) * 20f;
    }

    /// <summary>
    /// UIのスライダーのOnChangeValueイベントから呼び出されるメソッド
    /// </summary>
    /// <param name="sliderValue">スライダーの現在の値 (0.0～1.0)</param>
    public void SetVolume(float sliderValue)
    {
        float dbValue = ConvertSliderValueToDecibel(sliderValue);

        // Audio Mixerの公開パラメータにデシベル値を設定します
        mixer.SetFloat(volumeParameter, dbValue);
    }
}