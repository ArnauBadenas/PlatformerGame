using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{
    public GameObject GameOverScene;

    [ContextMenu("AddScore")]

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        GameOverScene.SetActive(true);
    }
}
