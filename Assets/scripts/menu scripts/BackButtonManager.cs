using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    public ButtonSoundManager soundManager; // Arraste seu ButtonSoundManager aqui no Inspector

    public void OnBackButtonClick()
    {
        // Reproduzir o som
        soundManager.PlayClickSound();

        // Mudar a cena após um pequeno atraso para garantir que o som seja ouvido
        Invoke("ChangeScene", 0.5f); // Ajuste o tempo conforme necessário
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("NomeDaSuaCena"); // Troque pelo nome da cena que deseja carregar
    }
}
