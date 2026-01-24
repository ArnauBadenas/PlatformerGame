using UnityEngine;

namespace Assets.Scripts.UI
{
    public class GameOverUI : MonoBehaviour
    {
        [SerializeField]
        private GameObject gameOverPanel;

        void OnEnable()
        {
            PlayerLife.OnPlayerDeath += ShowGameOverPanel;
        }

        void OnDisable()
        {
            PlayerLife.OnPlayerDeath -= ShowGameOverPanel;
        }

        private void ShowGameOverPanel()
        {
            gameOverPanel.SetActive(true);
        }
    }
}
