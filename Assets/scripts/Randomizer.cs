using System.Collections.Generic;
using UnityEngine;

public class Randomizer : MonoBehaviour
{
    public List<GameObject> cartas = new List<GameObject>(); // Lista de cartas
    public GameObject painel; // Cubo onde as cartas serão posicionadas
    public float startX = -5f; // Posição inicial X relativa ao painel
    public float startY = 0f; // Posição inicial Y relativa ao painel
    public float spacing = 2f; // Espaçamento entre as cartas
    public int numColunas = 3; // Número de colunas

    private Transform painelTransform;

    void Start()
    {
        if (painel != null)
        {
            painelTransform = painel.transform;
        }
        else
        {
            Debug.LogError("O painel não está atribuído.");
            return;
        }

        Debug.Log("Iniciando o embaralhamento e posicionamento das cartas...");
        ExibirObjetosSorteados();
    }

    public List<GameObject> SortearObjetos()
    {
        if (cartas.Count == 0)
        {
            Debug.LogWarning("A lista de cartas está vazia.");
            return new List<GameObject>();
        }

        List<GameObject> cartasSorteadas = new List<GameObject>(cartas);
        EmbaralharLista(cartasSorteadas);
        return cartasSorteadas;
    }

    private void EmbaralharLista(List<GameObject> lista)
    {
        int n = lista.Count;
        for (int i = n - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            GameObject temp = lista[i];
            lista[i] = lista[j];
            lista[j] = temp;
        }
    }

    public void ExibirObjetosSorteados()
    {
        List<GameObject> sorteados = SortearObjetos();
        Debug.Log("Objetos sorteados:");
        foreach (GameObject obj in sorteados)
        {
            Debug.Log(obj.name); // Apenas para verificar a ordem dos objetos
        }
        
        // Atualiza a lista de cartas com a lista embaralhada
        cartas = sorteados;
        
        // Posicionar as cartas
        PositionarCartas();
    }

    void PositionarCartas()
    {
        if (painelTransform == null)
        {
            Debug.LogError("O painel não está atribuído.");
            return;
        }

        // Obter a posição, escala e rotação do cubo
        Vector3 painelPosition = painelTransform.position;
        Vector3 painelSize = painelTransform.localScale;
        Quaternion painelRotation = painelTransform.rotation;

        // Determinar a profundidade da frente do cubo
        float frenteDistancia = painelSize.z * 1.1f; // Ajuste o multiplicador para garantir que as cartas fiquem à frente do cubo

        for (int i = 0; i < cartas.Count; i++)
        {
            int row = i / numColunas;
            int col = i % numColunas;

            // Calcula a posição local da carta com base no cubo
            Vector3 localPos = new Vector3(
                startX + col * spacing,
                startY,
                row * spacing
            );

            // Aplica a escala ao localPos
            Vector3 scaledPos = Vector3.Scale(localPos, painelSize);

            // Aplica a rotação do cubo
            Vector3 rotatedPos = painelRotation * scaledPos;

            // Calcula a posição final da carta no mundo e move para frente do cubo
            Vector3 novaPosicao = painelPosition + rotatedPos;
            novaPosicao.z += frenteDistancia; // Move as cartas para frente do cubo

            cartas[i].transform.position = novaPosicao;

            // Debug: Mostra a posição de cada carta
            Debug.Log($"Posição da carta {i}: {novaPosicao}");
        }
    }
}
