using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cartaPrefab; // Prefab da carta
    public Transform cartasContainer; // Contêiner onde as cartas serão instanciadas
    public int numPares = 6; // Número de pares de cartas

    private List<GameObject> cartas = new List<GameObject>();

    void Start()
    {
        List<int> valores = CriarBaralho();
        InstanciarCartas(valores);
        EmbaralharCartas();
    }

    List<int> CriarBaralho()
    {
        List<int> valores = new List<int>();
        for (int i = 0; i < numPares; i++)
        {
            valores.Add(i);
            valores.Add(i);
        }
        return valores;
    }

    void InstanciarCartas(List<int> valores)
    {
        foreach (int valor in valores)
        {
            GameObject carta = Instantiate(cartaPrefab, cartasContainer);
            carta.GetComponent<Carta>().Configurar(valor); // Configura o valor da carta
            cartas.Add(carta);
        }
    }

    void EmbaralharCartas()
    {
        for (int i = 0; i < cartas.Count; i++)
        {
            GameObject temp = cartas[i];
            int randomIndex = Random.Range(i, cartas.Count);
            cartas[i] = cartas[randomIndex];
            cartas[randomIndex] = temp;
        }

        // Posicionar as cartas na cena
        PositionarCartas();
    }

    void PositionarCartas()
    {
        if (cartas.Count == 0)
        {
            Debug.LogError("A lista de cartas está vazia. Nenhuma carta para posicionar.");
            return;
        }

        float cartaLargura = 0.462967217f; // Largura da carta
        float cartaAltura = 0.416074336f; // Altura da carta
        float spacing = 1.0f; // Espaçamento entre as cartas
        float startX = -960f; // Posição inicial X
        float startY = 540f; // Posição inicial Y

        int numColunas = 3; // Número de colunas

        for (int i = 0; i < cartas.Count; i++)
        {
            int row = i / numColunas;
            int col = i % numColunas;

            Vector3 novaPosicao = new Vector3(startX + col * (cartaLargura + spacing), startY - row * (cartaAltura + spacing), 0f);
            cartas[i].transform.position = novaPosicao;

            Debug.Log($"Posição da carta {i}: {novaPosicao}");
        }
    }
}
