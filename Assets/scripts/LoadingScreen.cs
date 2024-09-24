using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadingScreen : MonoBehaviour
{
    public Slider loadingSlider; // Arraste seu Slider aqui no Inspector
    public string nextSceneName = "Fase1"; // Nome da próxima cena
    public float loadingTime = 3f; // Tempo total para o carregamento (em segundos)

    private void Start()
    {
        StartCoroutine(LoadLevelAsync(nextSceneName)); // Inicia o carregamento da próxima cena
    }

    private IEnumerator LoadLevelAsync(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false; // Não ativa a cena até que o carregamento esteja completo

        float elapsedTime = 0f;

        while (!operation.isDone)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / loadingTime); // Progresso controlado pelo tempo

            loadingSlider.value = progress;

            // Ativa a cena quando o carregamento estiver completo
            if (elapsedTime >= loadingTime)
            {
                operation.allowSceneActivation = true; // Ativa a cena
            }

            yield return null; // Espera um frame antes de continuar
        }
    }
}
