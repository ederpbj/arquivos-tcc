using UnityEngine;
using UnityEngine.UI;

public class PlayButtonManager : MonoBehaviour
{
    public Button playButton; // Referência ao botão de jogar
    public AudioSource buttonClickSound; // Referência ao som do botão

    void Start()
    {
        if (playButton != null)
        {
            playButton.onClick.AddListener(OnPlayButtonClick);
        }
        else
        {
            Debug.LogError("PlayButton não está atribuído no Inspector!");
        }

        if (buttonClickSound == null)
        {
            Debug.LogError("ButtonClickSound não está atribuído no Inspector!");
        }
    }

    void OnPlayButtonClick()
    {
        if (buttonClickSound != null)
        {
            buttonClickSound.Play();
        }
        else
        {
            Debug.LogError("ButtonClickSound é nulo ao tentar tocar o som!");
        }
        // Adicione a lógica para iniciar o jogo, como SceneManager.LoadScene()
    }
}

