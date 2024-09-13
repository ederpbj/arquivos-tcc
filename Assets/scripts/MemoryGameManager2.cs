using UnityEngine;
using System.Collections;  // Adicione esta linha
using System.Collections.Generic;  // Adicione esta linha
using UnityEngine.UI;

public class MemoryGameManager2 : MonoBehaviour
{
    public Sprite[] cardImages;  // Imagens para as cartas
    public GameObject cardPrefab;  // Prefab da carta
    public Transform gridParent;  // Pai das cartas (grid layout)

    private GameObject firstCard, secondCard;
    private bool isChecking;

    void Start()
    {
        if (cardImages == null || cardPrefab == null || gridParent == null)
        {
            Debug.LogError("One or more references are not assigned.");
            return;
        }

        SetupCards();
    }

    void SetupCards()
    {
        List<Sprite> cardList = new List<Sprite>();
        foreach (var image in cardImages)
        {
            cardList.Add(image);
            cardList.Add(image);
        }

        cardList = cardList.OrderBy(x => Random.value).ToList(); // Embaralhar

        foreach (var cardImage in cardList)
        {
            GameObject card = Instantiate(cardPrefab, gridParent);
            Card cardComponent = card.GetComponent<Card>();
            if (cardComponent != null)
            {
                cardComponent.SetImage(cardImage);
                Button button = card.GetComponentInChildren<Button>();
                if (button != null)
                {
                    button.onClick.AddListener(() => OnCardClicked(card));
                }
                else
                {
                    Debug.LogError("Button component missing in card prefab.");
                }
            }
            else
            {
                Debug.LogError("Card component missing in card prefab.");
            }
        }
    }

    public void OnCardClicked(GameObject clickedCard)
    {
        if (isChecking || clickedCard == firstCard) return;

        StartCoroutine(FlipCard(clickedCard));

        if (firstCard == null)
        {
            firstCard = clickedCard;
        }
        else
        {
            secondCard = clickedCard;
            StartCoroutine(CheckCards());
        }
    }

    IEnumerator CheckCards()
    {
        isChecking = true;
        yield return new WaitForSeconds(1f);

        Card firstCardComponent = firstCard.GetComponent<Card>();
        Card secondCardComponent = secondCard.GetComponent<Card>();

        if (firstCardComponent != null && secondCardComponent != null)
        {
            if (firstCardComponent.GetImage() == secondCardComponent.GetImage())
            {
                firstCard.GetComponent<Button>().interactable = false;
                secondCard.GetComponent<Button>().interactable = false;
            }
            else
            {
                StartCoroutine(FlipCard(firstCard));
                StartCoroutine(FlipCard(secondCard));
            }
        }
        else
        {
            Debug.LogError("Card components missing.");
        }

        firstCard = null;
        secondCard = null;
        isChecking = false;
    }

    IEnumerator FlipCard(GameObject card)
    {
        Card cardComponent = card.GetComponent<Card>();
        if (cardComponent != null)
        {
            cardComponent.Flip();
            yield return new WaitForSeconds(0.5f); // Espera o tempo da animação de flip
        }
    }
}
