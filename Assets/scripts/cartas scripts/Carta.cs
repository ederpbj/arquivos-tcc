using UnityEngine;

public class Carta : MonoBehaviour
{
    public int valor; // Valor da carta
    public GameObject frente; // Referência ao quad da frente
    public GameObject verso; // Referência ao quad do verso

    public void Configurar(int novoValor)
    {
        valor = novoValor;
        // Configure a aparência da carta com base no valor
        // Exemplo: Ativar ou desativar a frente e o verso conforme o estado da carta
    }

    public void Virar()
    {
        // Lógica para virar a carta (alternar frente/verso)
        bool frenteAtiva = frente.activeSelf;
        frente.SetActive(!frenteAtiva);
        verso.SetActive(frenteAtiva);
    }
}
