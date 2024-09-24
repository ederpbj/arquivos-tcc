using UnityEngine;

public class ButtonSoundManager : MonoBehaviour
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
        if (audioSource != null && audioSource.enabled) // Verifica se o AudioSource está habilitado
        {
            audioSource.PlayOneShot(clickSound);
        }
        else
        {
            Debug.LogWarning("AudioSource está desativado!");
        }
    }
}
