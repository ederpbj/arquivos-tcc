using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSettings : MonoBehaviour
{
    public string settings; // Nome da cena de configurações

    public void OnOpenSettingsClick()
    {
        // Verifica se o nome da cena está definido
        if (!string.IsNullOrEmpty(settings))
        {
            // Carrega a cena de configurações
            SceneManager.LoadScene(settings);
        }
        else
        {
            Debug.LogError("Scene name for settings is not set in the Inspector.");
        }
    }
}
