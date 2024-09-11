using UnityEngine;
using UnityEngine.UI;

public class VolumeButtonController : MonoBehaviour
{
    public Sprite volumeOnSprite; // Imagem para volume ligado
    public Sprite volumeOffSprite; // Imagem para volume desligado
    private bool isMuted = false; // Estado do volume

    private Image buttonImage; // Imagem do botão

    private void Start()
    {
        buttonImage = GetComponent<Image>();
        
        if (buttonImage == null)
        {
            Debug.LogError("Image component not found on the GameObject.");
            return;
        }

        if (volumeOnSprite == null || volumeOffSprite == null)
        {
            Debug.LogError("One or more sprites are not assigned in the Inspector.");
            return;
        }
        
        buttonImage.sprite = volumeOnSprite; // Inicializa com o ícone de volume ligado
    }

    // Método chamado quando o botão é clicado
    public void ToggleVolume()
    {
        isMuted = !isMuted; // Alterna entre mudo e não mudo
        AudioListener.volume = isMuted ? 0f : 1f; // Define o volume como 0 ou 1
        buttonImage.sprite = isMuted ? volumeOffSprite : volumeOnSprite; // Alterna a imagem
    }
}
