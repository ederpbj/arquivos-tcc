using UnityEngine;
using UnityEngine.UI;

public class ButtonSoundManager : MonoBehaviour
{
    public Button optionsButton; // Referência ao botão de opções
    public AudioSource buttonClickSound; // Referência ao som do botão

    void Awake()
    {
        // Inicialize referências e verifique se estão atribuídas
        if (optionsButton == null)
        {
            Debug.LogError("OptionsButton não está atribuído no Awake!");
        }
        if (buttonClickSound == null)
        {
            Debug.LogError("ButtonClickSound não está atribuído no Awake!");
        }
    }

    void Start()
    {
        // Verificar se optionsButton e buttonClickSound não são nulos
        if (optionsButton != null)
        {
            if (buttonClickSound != null)
            {
                optionsButton.onClick.AddListener(PlayButtonClickSound);
            }
            else
            {
                Debug.LogError("ButtonClickSound é nulo na função Start!");
            }
        }
        else
        {
            Debug.LogError("OptionsButton é nulo na função Start!");
        }
    }

    void PlayButtonClickSound()
    {
        if (buttonClickSound != null)
        {
            buttonClickSound.Play();
        }
        else
        {
            Debug.LogError("ButtonClickSound é nulo ao tentar tocar o som!");
        }
    }
}
