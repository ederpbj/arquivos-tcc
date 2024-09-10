using UnityEngine;
using UnityEngine.UI;

public class ExitButtonManager : MonoBehaviour
{
    public Button exitButton; // Referência ao botão de sair
    public AudioSource buttonClickSound; // Referência ao som do botão

    void Start()
    {
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(OnExitButtonClick);
        }
        else
        {
            Debug.LogError("ExitButton não está atribuído no Inspector!");
        }

        if (buttonClickSound == null)
        {
            Debug.LogError("ButtonClickSound não está atribuído no Inspector!");
        }
    }

    void OnExitButtonClick()
    {
        if (buttonClickSound != null)
        {
            buttonClickSound.Play();
        }
        else
        {
            Debug.LogError("ButtonClickSound é nulo ao tentar tocar o som!");
        }
        // Adicione a lógica para sair do jogo, como Application.Quit()
    }
}
