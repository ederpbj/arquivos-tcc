using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject tutorialPanel; // Painel do tutorial
    public GameObject nextPanel; // Próximo painel
    public GameManager gameManager; // Referência ao GameManager

    void Start()
    {
        // Garante que o próximo painel esteja desativado
        if (nextPanel != null)
        {
            nextPanel.SetActive(false);
        }

        ShowTutorial(); // Exibe o painel de tutorial
    }

    public void ShowTutorial()
    {
        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(true); // Exibe o painel de tutorial
        }
    }

    public void HideTutorial()
    {
        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(false); // Esconde o painel de tutorial
        }
    }

    public void GoToNextPanel()
    {
    
        if (nextPanel != null)
        {
            nextPanel.SetActive(true); // Mostra o próximo painel
        }
    }

    public void GoBackToTutorial()
    {
        if (nextPanel != null)
        {
            nextPanel.SetActive(false); // Esconde o próximo painel
        }

        ShowTutorial(); // Mostra o painel anterior
    }

    public void SkipTutorial()
    {
        HideTutorial(); // Esconde o painel de tutorial
        gameManager.StartGame(); // Inicia o jogo após pular o tutorial
    }
}
