using UnityEngine;
using UnityEngine.SceneManagement; 

    // Necessário para carregar cenas

public class ReturnToMenu : MonoBehaviour
{
    // Este método será chamado quando o botão for clicado
    public void GoToMenu()
    {
        // Nome da cena do menu principal. Certifique-se de que está correto.
        SceneManager.LoadScene("MenuPrincipal");
    }
}
