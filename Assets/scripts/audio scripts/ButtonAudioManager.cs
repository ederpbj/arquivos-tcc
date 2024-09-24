using UnityEngine;

public class ButtonAudioManager : MonoBehaviour
{
    public AudioClip clickSound; // Arraste seu som aqui no Inspector
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = clickSound;
        audioSource.playOnAwake = false; // Não tocar automaticamente ao iniciar
    }

    public void PlayClickSound()
    {
        if (clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
    }

    // Método para ajustar o volume dos efeitos sonoros
    public void SetVolume(float volume)
    {
        audioSource.volume = volume; // Volume varia de 0.0f (mudo) a 1.0f (máximo)
        Debug.Log("Volume de efeitos sonoros ajustado para: " + volume); // Linha de debug
    }
}
