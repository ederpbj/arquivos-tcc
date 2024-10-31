using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameAdmin : MonoBehaviour
{
    public static int score = 0;
    public TextMeshProUGUI scoreText;
    public string gameOverSceneName = "FimDeJogo";
    public GameObject congratulationsPanel; // Painel de parabéns
    public AudioSource congratulationsSound; // Referência ao AudioSource
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
        congratulationsPanel.SetActive(false); // Inicialmente desativado
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
        ShowCongratulationsPanel();
    }

    private void ShowCongratulationsPanel()
    {
        congratulationsPanel.SetActive(true); // Mostra o painel
        UpdateScoreText(); // Atualiza a pontuação no painel
        congratulationsSound.Play(); // Toca o som de parabéns
    }

    public void ContinueToNextScene()
    {
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
            Debug.LogWarning("Fim das fases. Carregando a tela de Fim de Jogo.");
            SceneManager.LoadScene(gameOverSceneName);
        }
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

    private List<int> GetSceneIndicesFromBuildSettings()
    {
        List<int> sceneIndices = new List<int>();
        int sceneCount = SceneManager.sceneCountInBuildSettings;

        for (int i = 0; i < sceneCount; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string sceneName = System.IO.Path.GetFileNameWithoutExtension(scenePath);

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
