using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public static int score = 0;
    public TextMeshProUGUI scoreText;
    public string gameOverSceneName = "FimDeJogo";
    private List<string> sceneNames = new List<string> { "Fase-01", "Fase-02", "Fase-03" };
    private static List<string> shuffledScenes = new List<string>();
    private static int currentSceneIndex = 0;

    void Start()
    {
        if (shuffledScenes.Count == 0)
        {
            shuffledScenes = new List<string>(sceneNames);
            Shuffle(shuffledScenes);
        }
        UpdateScoreText();
    }

    void Update()
    {
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    public void AddPoints(int points)
    {
        score += points;
        Debug.Log($"Pontuação atual: {score}");
        UpdateScoreText();
    }

    public void SubtractPoints(int points)
    {
        score -= points;
        if (score < 0)
        {
            score = 0;
        }
        Debug.Log($"Pontuação atual: {score}");
        UpdateScoreText();
    }

    public void RespostaCorreta()
    {
        AddPoints(10);
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        if (currentSceneIndex < shuffledScenes.Count)
        {
            Debug.Log($"Carregando cena: {shuffledScenes[currentSceneIndex]}");
            SceneManager.LoadScene(shuffledScenes[currentSceneIndex]);
            currentSceneIndex++;
        }
        else
        {
            Debug.LogWarning("Não há mais cenas para carregar. Carregando a tela de Fim de Jogo.");
            SceneManager.LoadScene(gameOverSceneName);
        }
    }

    public void PularCena()
    {
        LoadNextScene();
    }

    public void RespostaErrada()
    {
        SubtractPoints(5);
    }

    public void MenuPrincipal()
    {
        score = 0;
        SceneManager.LoadScene("Menu");
    }

    public void ReiniciarJogo()
    {
        score = 0;
        currentSceneIndex = 0;
        shuffledScenes.Clear();
        shuffledScenes = new List<string>(sceneNames);
        Shuffle(shuffledScenes);
        LoadNextScene();
    }

    public void Jogar()
    {
        score = 0;
        currentSceneIndex = 0;
        shuffledScenes.Clear();
        shuffledScenes = new List<string>(sceneNames);
        Shuffle(shuffledScenes);
        LoadNextScene();
    }

    private void Shuffle<T>(IList<T> list)
    {
        System.Random rng = new System.Random();
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
