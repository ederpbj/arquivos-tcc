using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLimit = 120f; // 2 minutos em segundos
    private float timeRemaining;
    public TextMeshProUGUI TimerText; // Arraste o Text do UI aqui

    void Start()
    {
        timeRemaining = timeLimit;
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            // O que fazer quando o tempo acabar
            TimeUp();
        }
    }

    void UpdateTimerText()
    {
        TimerText.text = "Tempo: " + Mathf.Round(timeRemaining).ToString();
    }

    void TimeUp()
    {
        // Aqui você pode definir o que acontece quando o tempo acaba
        TimerText.text = "Tempo esgotado!";
        // Chame a função que finaliza a fase ou mostra a tela de Game Over
    }
}
