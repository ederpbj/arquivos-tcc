using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAdmin : MonoBehaviour
{
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;

    public void Jogar()
    {
        // Debug para verificar se o método é chamado
        Debug.Log("Botão Jogar memoria pressionado");

        // Chama o método Jogar do GameController
        GameObject gameController = GameObject.FindWithTag("GameAdmin");
        if (gameController != null)
        {
            Debug.Log("GameAdmin encontrado");
            gameController.GetComponent<GameController>().Jogar();
        }
        else
        {
            Debug.LogError("GameAdmin não encontrado");
        }
    }

    public void AbrirOpcoes()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void FecharOpcoes()
    {
        painelMenuInicial.SetActive(true);
        painelOpcoes.SetActive(false);
    }

    public void SairJogo()
    {
        Debug.Log("Sair do jogo");
        Application.Quit();
    }
}
