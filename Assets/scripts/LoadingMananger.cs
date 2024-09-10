using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Para carregar novas cenas

public class LoadingManager : MonoBehaviour
{
    public Slider loadingSlider;  // O Slider que representa a barra de carregamento
    public Image heart;           // A imagem do coração

    public float loadTime = 5f;   // Tempo total para carregar (em segundos)
    private float elapsedTime = 0f;

    void Start()
    {
        // Inicializa o Slider e o coração
        loadingSlider.value = 0f;
        UpdateHeartPosition(); // Ajusta a posição inicial do coração
    }

    void Update()
    {
        if (elapsedTime < loadTime)
        {
            elapsedTime += Time.deltaTime;
            float progress = Mathf.Clamp01(elapsedTime / loadTime);
            loadingSlider.value = progress;

            // Atualiza a posição do coração com base no progresso
            UpdateHeartPosition();
        }
        else if (elapsedTime >= loadTime && !SceneManager.GetActiveScene().name.Equals("NextScene"))
        {
            // Carregar a próxima cena quando o carregamento estiver completo
            SceneManager.LoadScene("Fase1"); // Substitua "NextScene" pelo nome da sua cena
        }
    }

    private void UpdateHeartPosition()
    {
        RectTransform sliderRect = loadingSlider.GetComponent<RectTransform>();
        RectTransform heartRect = heart.rectTransform;

        // Calcula a posição do coração ao longo da barra
        float sliderWidth = sliderRect.rect.width;
        float heartWidth = heartRect.rect.width;

        // A posição do coração deve ser ajustada para a largura da barra
        float newX = sliderWidth * (loadingSlider.value - 0.5f) - (heartWidth / 25);

        heartRect.anchoredPosition = new Vector2(newX, heartRect.anchoredPosition.y);
    }
}
