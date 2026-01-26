using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour
{
    private Text scoreText;

    private void Awake()
    {
        scoreText = GetComponent<Text>();
        scoreText.text = "Final score: " + ScoreSystem.FinalScore;
    }
}
