using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager1 : MonoBehaviour
{
    [SerializeField] private GameObject painelMenuInicial; // Referência ao painel inicial
    [SerializeField] private GameObject painelOpcoes; // Referência ao painel de opções

    private void Start()
    {
        // Inicialmente, mostra o painel principal e oculta o painel de opções
        if (painelMenuInicial != null)
        {
            painelMenuInicial.SetActive(true);
        }

        if (painelOpcoes != null)
        {
            painelOpcoes.SetActive(false);
        }
    }

    public void AbrirOpcoes()
    {
        // Oculta o painel inicial e mostra o painel de opções
        if (painelMenuInicial != null)
        {
            painelMenuInicial.SetActive(false);
        }

        if (painelOpcoes != null)
        {
            painelOpcoes.SetActive(true);
        }
    }

    public void FecharOpcoes()
    {
        // Oculta o painel de opções e mostra o painel inicial
        if (painelOpcoes != null)
        {
            painelOpcoes.SetActive(false);
        }

        if (painelMenuInicial != null)
        {
            painelMenuInicial.SetActive(true);
        }
    }

    // Opcional: Método para voltar à cena de jogo
    public void VoltarParaCena(string nomeCena)
    {
        SceneManager.LoadScene(nomeCena);
    }
}
