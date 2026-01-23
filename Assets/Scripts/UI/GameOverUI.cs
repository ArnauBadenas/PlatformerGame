using UnityEngine;

namespace Assets.Scripts.UI
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverPanel;
        private void OnEnable()
        {
            PlayerLife.OnPlayerDeath += showGameOverPanel;
        }

        private void OnDisable()
        {
            PlayerLife.OnPlayerDeath -= showGameOverPanel;
        }

        private void showGameOverPanel()
        {
            gameOverPanel.SetActive(true);
        }
    }
}
