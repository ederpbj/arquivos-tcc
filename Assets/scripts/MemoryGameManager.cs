using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGameManager : MonoBehaviour
{
    [Serializable] public GameObject[] cards; // Array para as cartas
    public Transform[] cardPositions; // Posições onde as cartas serão colocadas

    void Start()
    {
        ShuffleCards();
        PlaceCards();
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
}
