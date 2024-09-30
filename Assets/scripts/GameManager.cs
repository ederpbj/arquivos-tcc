using UnityEngine;
using TMPro; // Importa o namespace do TextMeshPro

public class GameManager : MonoBehaviour
{
    public float gameTime = 100f; // Tempo total do jogo
    private float timer;
    
    public TextMeshProUGUI timerText; // Referência para o componente TextMeshPro

    void Start()
    {
        timer = 0f; // Inicializa o timer
        UpdateTimerText(); // Atualiza o texto do timer no início
    }

    void Update()
    {
        if (timer < gameTime)
        {
            timer += Time.deltaTime; // Incrementa o timer enquanto o jogo estiver ativo
            UpdateTimerText(); // Atualiza o texto do timer
        }
    }

    public void StartGame()
    {
        timer = 0f; // Reinicia o timer
        UpdateTimerText(); // Atualiza o texto ao iniciar o jogo
    }

    private void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = "Tempo: " + Mathf.RoundToInt(gameTime - timer).ToString(); // Atualiza o texto com o tempo restante
        }
    }

    public float GetTime()
    {
        return timer; // Retorna o tempo atual
    }
}
