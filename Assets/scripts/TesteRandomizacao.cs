using UnityEngine;

public class TesteRandomizacao : MonoBehaviour
{
    public Randomizer randomizer; // Referência ao script Randomizer

    void Start()
    {
        if (randomizer != null)
        {
            // Chama o método ExibirObjetosSorteados para testar
            randomizer.ExibirObjetosSorteados();
        }
        else
        {
            Debug.LogError("Referência ao Randomizer não está definida.");
        }
    }
}

