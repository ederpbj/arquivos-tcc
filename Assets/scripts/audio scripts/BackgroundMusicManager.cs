using UnityEngine;

public class BackgroundMusicManager : MonoBehaviour
{
    public AudioSource musicSource; // Referência ao componente AudioSource
    public AudioClip backgroundMusic; // Referência ao clipe de áudio da música de fundo

    void Start()
    {
        if (musicSource != null && backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true; // Configura para repetir a música
            musicSource.Play(); // Inicia a reprodução da música
        }
        else
        {
            Debug.LogWarning("AudioSource or AudioClip is not assigned.");
        }
    }
}
