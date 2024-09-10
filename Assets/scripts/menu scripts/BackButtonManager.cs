using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Necessário para gerenciar cenas

public class BackButtonManager : MonoBehaviour
{
    public Button backButton;         // Referência ao botão "Voltar"
    public AudioSource buttonClickSound; // Referência ao som do botão

    void Start()
    {
        // Adiciona um listener ao botão "Voltar"
        if (backButton != null)
        {
            backButton.onClick.AddListener(OnBackButtonClick);
        }
        else
        {
            Debug.LogError("BackButton não está atribuído no Inspector!");
        }

        // Verifica se o AudioSource está atribuído
        if (buttonClickSound == null)
        {
            Debug.LogError("ButtonClickSound não está atribuído no Inspector!");
        }
    }

    void OnBackButtonClick()
    {
        // Reproduz o som do botão
        if (buttonClickSound != null)
        {
            buttonClickSound.Play();
        }
        else
        {
            Debug.LogError("ButtonClickSound é nulo ao tentar tocar o som!");
        }

        // Lógica para retornar à cena anterior
        GoBackToPreviousScene();
    }

    void GoBackToPreviousScene()
    {
        // Retorna à cena anterior. Gerencie o histórico de cenas conforme necessário
        if (SceneManager.sceneCountInBuildSettings > 1) // Verifica se há mais de uma cena disponível
        {
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
            if (currentSceneIndex > 0) // Verifica se não é a primeira cena
            {
                SceneManager.LoadScene(currentSceneIndex - 1);
            }
            else
            {
                Debug.LogWarning("Não há uma cena anterior disponível.");
            }
        }
        else
        {
            Debug.LogWarning("Não há cenas suficientes para voltar.");
        }
    }
}
