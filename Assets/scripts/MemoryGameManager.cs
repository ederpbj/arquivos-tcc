using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Importante para trabalhar com UI

public class MemoryGameManager : MonoBehaviour
{
    public GameObject[] cards; // Array para as cartas
    public Transform[] cardPositions; // Posições onde as cartas serão colocadas
    public Button shuffleButton; // Referência ao botão de embaralhar

    void Start()
    {
        ShuffleCards();
        PlaceCards();

        // Associar a função ShuffleAndPlace ao clique do botão
        shuffleButton.onClick.AddListener(ShuffleAndPlace);
    }

    // Função para embaralhar as cartas usando Fisher-Yates Shuffle
    void ShuffleCards()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            GameObject temp = cards[i];
            int randomIndex = Random.Range(i, cards.Length);
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }
    }

    // Função para posicionar as cartas nos locais da tela
    void PlaceCards()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            // Posiciona cada carta em uma das posições predefinidas
            cards[i].transform.position = cardPositions[i].position;
        }
    }

    // Função chamada ao clicar no botão para embaralhar e reposicionar as cartas
    public void ShuffleAndPlace()
    {
        ShuffleCards();
        PlaceCards();
    }
}
