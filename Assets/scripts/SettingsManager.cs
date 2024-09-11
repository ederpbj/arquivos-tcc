using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public GameObject settingsPanel; // Referência ao painel de configurações

    private void Start()
    {
        // Inicialmente, oculta o painel de configurações
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }
    }

    // Método para abrir o painel de configurações
    public void OpenSettings()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(true);
        }
    }

    // Método para fechar o painel de configurações
    public void CloseSettings()
    {
        if (settingsPanel != null)
        {
            settingsPanel.SetActive(false);
        }
    }
}
