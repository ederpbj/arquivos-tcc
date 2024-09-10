using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource; // Referência ao AudioSource para a música de fundo
    public AudioSource soundEffectsSource; // Referência ao AudioSource para os efeitos sonoros
    public Slider musicVolumeSlider; // Referência ao Slider de volume da música
    public Slider soundEffectsVolumeSlider; // Referência ao Slider de volume dos efeitos sonoros

    void Start()
    {
        // Verificar se musicVolumeSlider não é nulo
        if (musicVolumeSlider != null)
        {
            musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f); // 1 é o valor padrão
            musicVolumeSlider.onValueChanged.AddListener(SetMusicVolume);
        }
        else
        {
            Debug.LogError("MusicVolumeSlider não está atribuído!");
        }

        // Verificar se soundEffectsVolumeSlider não é nulo
        if (soundEffectsVolumeSlider != null)
        {
            soundEffectsVolumeSlider.value = PlayerPrefs.GetFloat("SoundEffectsVolume", 1f); // 1 é o valor padrão
            soundEffectsVolumeSlider.onValueChanged.AddListener(SetSoundEffectsVolume);
        }
        else
        {
            Debug.LogError("SoundEffectsVolumeSlider não está atribuído!");
        }

        // Verificar se musicSource não é nulo
        if (musicSource == null)
        {
            Debug.LogError("MusicSource não está atribuído!");
        }

        // Verificar se soundEffectsSource não é nulo
        if (soundEffectsSource == null)
        {
            Debug.LogError("SoundEffectsSource não está atribuído!");
        }
    }

    public void SetMusicVolume(float volume)
    {
        if (musicSource != null)
        {
            musicSource.volume = volume;
            PlayerPrefs.SetFloat("MusicVolume", volume); // Salvar o valor no PlayerPrefs
        }
        else
        {
            Debug.LogError("MusicSource é nulo na função SetMusicVolume!");
        }
    }

    public void SetSoundEffectsVolume(float volume)
    {
        if (soundEffectsSource != null)
        {
            soundEffectsSource.volume = volume;
            PlayerPrefs.SetFloat("SoundEffectsVolume", volume); // Salvar o valor no PlayerPrefs
        }
        else
        {
            Debug.LogError("SoundEffectsSource é nulo na função SetSoundEffectsVolume!");
        }
    }
}
