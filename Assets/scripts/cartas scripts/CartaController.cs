using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaController : MonoBehaviour
{
    [SerializeField] private GameObject cartaFrente;
    [SerializeField] private GameObject cartaVerso;

    // Referência ao GameAdmin para gerenciar a pontuação e trocar cenas
    private GameAdmin gameAdmin;

    // Variáveis para controle de clique e comparação de cartas
    private static CartaController primeiroClick = null;
    private static CartaController segundoClick = null;
    private static bool bloqueioInput = false;

    // Variável de proteção de clique
    private bool protecaoAtivada = false;

    // Lista de todas as cartas na cena
    private static List<CartaController> todasCartas;

    // Inicialização
    void Start()
    {
        // Encontrar o GameAdmin na cena
        gameAdmin = FindObjectOfType<GameAdmin>();

        // Adicionar esta carta à lista de todas as cartas
        if (todasCartas == null)
        {
            todasCartas = new List<CartaController>();
        }
        todasCartas.Add(this);

        FecharCarta(); // Fechar a carta no início
    }

    // Função para abrir a carta
    public void AbrirCarta()
    {
        // Verificar se a interação está bloqueada ou se a carta já foi clicada
        if (!bloqueioInput && !protecaoAtivada && (primeiroClick == null || segundoClick == null))
        {
            // Impedir o jogador de clicar na mesma carta duas vezes
            if (primeiroClick == this) return;

            cartaFrente.SetActive(false);
            cartaVerso.SetActive(true);

            // Ativar proteção para a carta que foi clicada
            protecaoAtivada = true;

            if (primeiroClick == null)
            {
                // Primeiro clique
                primeiroClick = this;
            }
            else if (segundoClick == null)
            {
                // Segundo clique
                segundoClick = this;

                // Comparar tags das cartas
                if (primeiroClick.CompareTag(segundoClick.tag))
                {
                    // Tags correspondem, adicionar pontos através do GameAdmin
                    gameAdmin.AddPoints(10);
                    StartCoroutine(ReiniciarClicks(true));
                }
                else
                {
                    // Tags não correspondem, subtrair pontos através do GameAdmin
                    gameAdmin.SubtractPoints(5);
                    StartCoroutine(ReiniciarClicks(false));
                }
            }
        }
    }

    // Função para fechar a carta
    public void FecharCarta()
    {
        cartaFrente.SetActive(true);
        cartaVerso.SetActive(false);
    }

    // Corrutina para reiniciar os cliques após comparação
    IEnumerator ReiniciarClicks(bool match)
    {
        bloqueioInput = true; // Bloquear novas interações até a comparação terminar
        yield return new WaitForSeconds(1f); // Tempo de espera para o jogador ver as cartas

        if (!match)
        {
            // Se não houve correspondência, fechar as cartas
            primeiroClick.FecharCarta();
            segundoClick.FecharCarta();
        }

        // Desativar a proteção de clique nas cartas
        primeiroClick.protecaoAtivada = false;
        segundoClick.protecaoAtivada = false;

        // Resetar os clicks
        primeiroClick = null;
        segundoClick = null;
        bloqueioInput = false; // Desbloquear interações

        // Verificar se todas as cartas foram combinadas
        if (TodasCartasCombinadas())
        {
            // Chamar a próxima cena através do GameAdmin
            gameAdmin.RespostaCorreta();
        }
    }

    // Função para verificar se todas as cartas foram combinadas
    private bool TodasCartasCombinadas()
    {
        foreach (CartaController carta in todasCartas)
        {
            if (carta.cartaFrente.activeSelf) // Se a frente da carta ainda está ativa, ela não foi combinada
            {
                return false;
            }
        }
        return true;
    }

    // Função para embaralhar as cartas no início do jogo
    public static void EmbaralharCartas(List<CartaController> todasCartas)
    {
        // Embaralhar a lista de cartas
        for (int i = 0; i < todasCartas.Count; i++)
        {
            Vector3 tempPosition = todasCartas[i].transform.position;
            int randomIndex = Random.Range(0, todasCartas.Count);
            todasCartas[i].transform.position = todasCartas[randomIndex].transform.position;
            todasCartas[randomIndex].transform.position = tempPosition;
        }
    }
}
