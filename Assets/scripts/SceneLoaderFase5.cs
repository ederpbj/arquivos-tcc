using UnityEngine;
using UnityEngine.SceneManagement; // Necessário para carregar cenas

public class SceneLoaderFase5 : MonoBehaviour
{
    // Nome da cena que será carregada quando o Quad for clicado
    private string sceneName = "Fase5";

    void OnMouseDown()
    {
        // Carregar a cena com base no nome
        SceneManager.LoadScene(sceneName);
    }
}
