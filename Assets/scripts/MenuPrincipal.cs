using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;

    public void Jogar()
    {
        // Debug para verificar se o método é chamado
        Debug.Log("Botão Jogar pressionado");

        // Chama o método Jogar do GameController
        GameObject gameController = GameObject.FindWithTag("GameController");
        if (gameController != null)
        {
            Debug.Log("GameController encontrado");
            gameController.GetComponent<GameController>().Jogar();
        }
        else
        {
            Debug.LogError("GameController não encontrado");
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
