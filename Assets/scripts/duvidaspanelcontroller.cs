using UnityEngine;
using UnityEngine.UI;

public class DúvidasPanelController : MonoBehaviour
{
    public GameObject primeiroPainel; // Primeiro painel de dúvidas
    public GameObject segundoPainel; // Segundo painel de dúvidas
    public Button nextButton; // Botão para passar pro lado
    public Button backButton; // Botão para voltar
    public Button continueButton; // Botão para continuar

    private int currentPanel = 1; // 1 para o primeiro painel, 2 para o segundo

    void Start()
    {
        // Garante que ambos os painéis estejam fechados no início
        primeiroPainel.SetActive(false);
        segundoPainel.SetActive(false);

        // Adiciona os listeners aos botões
        nextButton.onClick.AddListener(ShowNextDúvida);
        backButton.onClick.AddListener(ShowPreviousDúvida);
        continueButton.onClick.AddListener(CloseDúvidasPanel);
    }

    public void ShowNextDúvida()
    {
        if (currentPanel == 1)
        {
            // Muda para o segundo painel
            primeiroPainel.SetActive(false);
            segundoPainel.SetActive(true);
            currentPanel = 2;
        }
    }

    public void ShowPreviousDúvida()
    {
        if (currentPanel == 2)
        {
            // Volta para o primeiro painel
            segundoPainel.SetActive(false);
            primeiroPainel.SetActive(true);
            currentPanel = 1;
        }
    }

    public void CloseDúvidasPanel()
    {
        primeiroPainel.SetActive(false); // Fecha o painel de dúvidas
        segundoPainel.SetActive(false); // Fecha o segundo painel
    }

    public void OpenDúvidasPanel()
    {
        primeiroPainel.SetActive(true); // Abre o primeiro painel de dúvidas
        segundoPainel.SetActive(false); // Garante que o segundo painel esteja fechado
        currentPanel = 1; // Inicia no primeiro painel
    }
}
