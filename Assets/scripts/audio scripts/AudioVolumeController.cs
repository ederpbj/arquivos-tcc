using UnityEngine;
using UnityEngine.UI;

public class AudioVolumeController : MonoBehaviour
{
    public MusicManager musicManager; // Arraste seu MusicManager aqui no Inspector
    public ButtonAudioManager buttonAudioManager; // Arraste seu ButtonAudioManager aqui no Inspector
    public Slider musicVolumeSlider; // Arraste o slider de volume de música aqui no Inspector
    public Slider soundVolumeSlider; // Arraste o slider de volume de efeitos sonoros aqui no Inspector

    void Start()
    {
        musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        soundVolumeSlider.onValueChanged.AddListener(SetSoundVolume);
    }

    public void SetMusicVolume(float volume)
    {
        if (musicManager != null)
        {
            musicManager.SetVolume(volume);
        }
    }

    public void SetSoundVolume(float volume)
    {
        if (buttonAudioManager != null)
        {
            buttonAudioManager.SetVolume(volume);
            Debug.Log("Volume de efeitos sonoros ajustado para: " + volume); // Linha de debug
        }
    }
}
