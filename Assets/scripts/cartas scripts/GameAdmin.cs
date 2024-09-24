using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameAdmin : MonoBehaviour
{
    public static int score = 0;
    public TextMeshProUGUI scoreText;
    public string gameOverSceneName = "FimDeJogo";
    private static List<int> shuffledSceneIndices = new List<int>();
    private static int currentSceneIndex = 0;

    void Start()
    {
        if (shuffledSceneIndices.Count == 0)
        {
            shuffledSceneIndices = GetSceneIndicesFromBuildSettings();
            Shuffle(shuffledSceneIndices);
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
    if (currentSceneIndex < shuffledSceneIndices.Count)
    {
        int nextSceneIndex = shuffledSceneIndices[currentSceneIndex];
        Debug.Log($"Carregando cena de índice: {nextSceneIndex}");
        SceneManager.LoadScene(nextSceneIndex);
        currentSceneIndex++;
    }
    else
    {
        // Após a última fase, carregar a cena de "Fim-de-fase"
        Debug.LogWarning("Fim das fases. Carregando a tela de Fim de Fase.");
        SceneManager.LoadScene("Fim-de-fase");
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
        shuffledSceneIndices.Clear();
        shuffledSceneIndices = GetSceneIndicesFromBuildSettings();
        Shuffle(shuffledSceneIndices);
        LoadNextScene();
    }

public void Jogar()
{
    score = 0;
    currentSceneIndex = 0;
    shuffledSceneIndices.Clear();
    shuffledSceneIndices = GetSceneIndicesFromBuildSettings();
    Shuffle(shuffledSceneIndices);

    // Carregar diretamente "Fase-01"
    SceneManager.LoadScene("Fase-01");
}

    // Função para obter os índices de cena do Build Settings
    private List<int> GetSceneIndicesFromBuildSettings()
    {
        List<int> sceneIndices = new List<int>();
        int sceneCount = SceneManager.sceneCountInBuildSettings;

        // Adiciona todas as cenas do Build Settings (exceto a cena de Game Over)
        for (int i = 0; i < sceneCount; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);

            // Ignorar a cena de Game Over, se for a última
            if (!sceneName.Equals(gameOverSceneName))
            {
                sceneIndices.Add(i);
            }
        }
        return sceneIndices;
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
