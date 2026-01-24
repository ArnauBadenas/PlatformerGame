using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicManager : MonoBehaviour
{
    public int PlayerScore;
    public Text ScoreText;
    public GameObject GameOverScene;

    [ContextMenu("AddScore")]

    public void AddScore()
    {
        PlayerScore += 1;
        ScoreText.text = PlayerScore.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver()
    {
        GameOverScene.SetActive(true);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        //aquí configurar el código con el comportamiento de colisiones del monito
    }
}
