using UnityEngine;
using TMPro; // Para usar o TextMesh Pro
using UnityEngine.UI; // Para usar UI, incluindo Button
using UnityEngine.SceneManagement;

public class MemoryGame : MonoBehaviour
{
    public GameObject[] cards; // Array de cartas
    public GameObject congratulationsPanel; // Painel de parabéns
    public TMP_Text finalScoreText; // Texto para mostrar a pontuação final
    public Button backButton; // Botão para voltar ao menu
    public Button continueButton; // Botão para continuar para a próxima fase

    private int pairsFound = 0; // Contador de pares encontrados
    private int score = 0; // Pontuação do jogador
    private const int totalPairs = 4; // Total de pares no jogo

    private Button firstCardButton; // Primeira carta virada
    private Button secondCardButton; // Segunda carta virada

    void Start()
    {
        // Esconde o painel de parabéns inicialmente
        congratulationsPanel.SetActive(false);
    }

    public void OnCardClicked(Button cardButton)
    {
        if (firstCardButton == null)
        {
            firstCardButton = cardButton;
            FlipCard(cardButton);
        }
        else if (secondCardButton == null && cardButton != firstCardButton)
        {
            secondCardButton = cardButton;
            FlipCard(cardButton);
            StartCoroutine(CheckForMatch());
        }
    }

    private void FlipCard(Button cardButton)
    {
        // Acessa os GameObjects de frente e verso
        Transform front = cardButton.transform.Find("Front");
        Transform back = cardButton.transform.Find("Back");

        if (front != null && back != null)
        {
            front.gameObject.SetActive(true); // Mostra a frente da carta
            back.gameObject.SetActive(false); // Esconde o verso da carta
            Debug.Log("Carta virada: " + cardButton.name);
        }
    }

    private System.Collections.IEnumerator CheckForMatch()
    {
        // Espera um tempo para mostrar as cartas viradas
        yield return new WaitForSeconds(1f);

        // Verifica se as cartas combinam
        if (firstCardButton.name == secondCardButton.name) // Lógica de comparação
        {
            pairsFound++;
            score += 10; // Aumenta a pontuação ao encontrar um par
            Debug.Log("Par encontrado! Total de pares: " + pairsFound);
        }
        else
        {
            // Inverte as cartas de volta após um curto período
            FlipBack(firstCardButton);
            FlipBack(secondCardButton);
        }

        // Limpa as cartas viradas
        firstCardButton = null;
        secondCardButton = null;

        // Verifica se todos os pares foram encontrados
        if (pairsFound >= totalPairs)
        {
            ShowCongratulationsPanel();
        }
    }

    private void FlipBack(Button cardButton)
    {
        // Acessa os GameObjects de frente e verso
        Transform front = cardButton.transform.Find("Front");
        Transform back = cardButton.transform.Find("Back");

        if (front != null && back != null)
        {
            front.gameObject.SetActive(false); // Esconde a frente da carta
            back.gameObject.SetActive(true); // Mostra o verso da carta
            Debug.Log("Carta revertida: " + cardButton.name);
        }
    }

    private void ShowCongratulationsPanel()
    {
        finalScoreText.text = " " + score.ToString();
        congratulationsPanel.SetActive(true); // Mostra o painel de parabéns
        Debug.Log("Todos os pares encontrados! Mostrando painel de parabéns.");
    }

    // Função chamada quando o botão "Voltar para o Menu" é clicado
    public void OnBackToMenu()
    {
        SceneManager.LoadScene("MenuPrincipal"); // Nome da sua cena de menu
    }

    // Função chamada quando o botão "Continuar" é clicado
    public void OnContinue()
    {
        SceneManager.LoadScene("FimDeJogo"); // Nome da próxima fase
    }
}
