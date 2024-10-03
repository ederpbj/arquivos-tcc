using UnityEngine;

public class GameManager1 : MonoBehaviour
{
    public static GameManager1 Instance; // Singleton para acesso global
    public int score;

    private void Awake()
    {
        // Configurar o Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Mantém o objeto entre as cenas
        }
        else
        {
            Destroy(gameObject); // Destroi o objeto duplicado
        }
    }

    // Método para adicionar pontos
    public void AddPoints(int points)
    {
        score += points;
    }
}
