using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    public GameObject optionsPanel; // Referência ao painel de opções

    private void Start()
    {
        // Inicialmente, oculta o painel de opções
        if (optionsPanel != null)
        {
            optionsPanel.SetActive(false);
        }
    }

    public void ToggleOptionsPanel()
    {
        if (optionsPanel != null)
        {
            // Alterna a visibilidade do painel de opções
            optionsPanel.SetActive(!optionsPanel.activeSelf);
        }
    }
}


