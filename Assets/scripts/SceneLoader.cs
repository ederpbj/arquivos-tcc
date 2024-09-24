using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para carregar cenas
using UnityEngine.UI; // Necessário para usar componentes UI

public class SceneLoader : MonoBehaviour
{
    // Nome da cena que será carregada
    public string sceneName = "Fase1";

    // Método chamado ao clicar no botão
    public void LoadScene()
    {
        // Carregar a cena com base no nome
        SceneManager.LoadScene(sceneName);
    }
}
