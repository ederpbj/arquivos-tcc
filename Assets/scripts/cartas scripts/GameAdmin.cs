using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameAdmin : MonoBehaviour
{
    public GameObject congratulationsPanel; // Painel de Parabéns
    public GameObject gameOverPanel; // Painel de Game Over
    public Text scoreText; // Texto que mostra a pontuação
    public float timeLimit = 100f; // Tempo total
    private float timeRemaining;
    private int score = 0;
    private int matchedPairs = 0; // Para contar os pares encontrados

    void Start()
    {
        timeRemaining = timeLimit;
        gameOverPanel.SetActive(false);
        congratulationsPanel.SetActive(false);
    }

    void Update()
    {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            ShowGameOver();
        }
    }

    public void OnLevelComplete()
    {
        congratulationsPanel.SetActive(true);
        scoreText.text = "Pontuação: " + score; // Mostra a pontuação
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    public void Retry()
    {
        // Reinicia o nível
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddScore(int points)
    {
        score += points; // Adiciona os pontos ao total
    }

    public void OnCardMatched()
    {
        AddScore(5); // Aumenta a pontuação em 5 para cada par encontrado
        matchedPairs++; // Aumenta a contagem de pares encontrados

        // Verifica se o jogador completou o jogo
        if (matchedPairs >= 4) // Já que você tem 4 pares
        {
            OnLevelComplete();
        }
    }
}
