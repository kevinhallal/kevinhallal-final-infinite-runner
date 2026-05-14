using UnityEngine;
using UnityEngine.UI;

public class AudioSettingsManager : MonoBehaviour
{
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    private const string MusicKey = "MusicVolume";
    private const string SfxKey = "SFXVolume";

    void Start()
    {
        musicSlider.value = PlayerPrefs.GetFloat(MusicKey, 1f);
        sfxSlider.value = PlayerPrefs.GetFloat(SfxKey, 1f);

        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetMusicVolume(float value)
    {
        PlayerPrefs.SetFloat(MusicKey, value);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float value)
    {
        PlayerPrefs.SetFloat(SfxKey, value);
        PlayerPrefs.Save();
    }
}