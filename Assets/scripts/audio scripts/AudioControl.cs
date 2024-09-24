using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public MusicManager musicManager; // Arraste seu MusicManager aqui no Inspector
    public ButtonAudioManager buttonAudioManager; // Arraste um ButtonAudioManager aqui no Inspector
    public Slider musicVolumeSlider; // Arraste o slider de volume de música
    public Slider soundVolumeSlider; // Arraste o slider de volume de efeitos sonoros

    void Start()
    {
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        soundVolumeSlider.onValueChanged.AddListener(SetSoundVolume);
    }

    public void SetMusicVolume(float volume)
    {
        musicManager.SetVolume(volume);
    }

    public void SetSoundVolume(float volume)
    {
        buttonAudioManager.SetVolume(volume);
    }
}
