using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MeuJogo
{
    public class GameManager1 : MonoBehaviour
    {
        public GameObject panelGameOver; // Painel de Game Over
        public GameObject panelParabens; // Painel de Parabéns
        public Text scoreText; // Texto para mostrar a pontuação
        public float tempoLimite = 60f; // Tempo total do jogo
        private float tempoRestante;

        public List<MeuJogo> cartas; // Lista de cartas (certifique-se de que a classe Card está definida)
        private bool faseCompleta = false;
        private int score = 0; // Pontuação total

        void Start()
        {
            tempoRestante = tempoLimite;
            panelGameOver.SetActive(false);
            panelParabens.SetActive(false);
            AtualizarPontuacao(); // Inicializa a pontuação na UI
        }

        void Update()
        {
            if (tempoRestante > 0 && !faseCompleta)
            {
                tempoRestante -= Time.deltaTime;
            }
            else if (tempoRestante <= 0 && !faseCompleta)
            {
                TempoAcabou();
            }

            // Verifica se a fase foi completada
            if (!faseCompleta && VerificarFaseCompleta())
            {
                faseCompleta = true;
                FaseCompleta();
            }
        }

        void TempoAcabou()
        {
            panelGameOver.SetActive(true);
            // Aqui você pode parar o jogo ou desativar a interação do jogador
        }

        public void FaseCompleta()
        {
            panelParabens.SetActive(true);
            AtualizarPontuacao(); // Atualiza a pontuação no painel de Parabéns
        }

        public void ReiniciarJogo()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void VoltarParaMenu()
        {
            SceneManager.LoadScene("Menu"); // Certifique-se de que você tenha uma cena chamada "Menu"
        }

        public void ProximaFase()
        {
            // Carregue a próxima fase
            // Exemplo: SceneManager.LoadScene("Fase2");
        }

        private bool VerificarFaseCompleta()
        {
            // Verifica se todas as cartas foram emparelhadas
            foreach (var carta in cartas)
            {
                if (!carta.Emparelhada) // Supondo que você tenha uma propriedade "Emparelhada" na classe Card
                {
                    return false;
                }
            }
            return true;
        }

        public void AdicionarPontuacao(int pontos)
        {
            score += pontos; // Adiciona pontos à pontuação total
            AtualizarPontuacao(); // Atualiza a pontuação na UI
        }

        private void AtualizarPontuacao()
        {
            scoreText.text = "Pontuação: " + score; // Atualiza o texto da pontuação
        }
    }
}
