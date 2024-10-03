using UnityEngine;
using TMPro; // Importa a biblioteca TextMeshPro
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ParabensPanelController : MonoBehaviour
{
    public GameObject parabenPanel; // O painel de "Parabéns"
    public TextMeshProUGUI pontuacaoText; // Texto para exibir a pontuação (TextMeshPro)
    public Button continuarButton; // Botão para continuar
    public Button menuButton; // Botão para voltar ao menu

    // Método para mostrar o painel de parabéns
    public void MostrarParabens(int pontuacao)
    {
        // Ativa o painel
        parabenPanel.SetActive(true);
        // Define a pontuação no texto
        pontuacaoText.text = "Parabéns! Sua pontuação: " + pontuacao.ToString();

        // Adiciona os listeners para os botões
        continuarButton.onClick.AddListener(Continuar);
        menuButton.onClick.AddListener(VoltarAoMenu);
    }

    // Método para continuar para a próxima fase
    private void Continuar()
    {
        // Aqui você pode adicionar lógica para carregar a próxima cena
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Método para voltar ao menu
    private void VoltarAoMenu()
    {
        // Aqui você deve definir o nome da sua cena do menu
        SceneManager.LoadScene("MenuPrincipal"); // Substitua "MenuScene" pelo nome correto
    }
}


