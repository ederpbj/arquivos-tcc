using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play(); // Iniciar a música ao carregar a cena
    }

    // Método para ajustar o volume
    public void SetVolume(float volume)
    {
        audioSource.volume = volume; // Volume varia de 0.0f (mudo) a 1.0f (máximo)
    }
}
