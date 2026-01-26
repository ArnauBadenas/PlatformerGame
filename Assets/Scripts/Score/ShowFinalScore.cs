using UnityEngine;
using UnityEngine.UI;

public class ShowFinalScore : MonoBehaviour
{
    private Text labelFinalScore;

    private void Awake()
    {
        labelFinalScore = GetComponent<Text>();
        labelFinalScore.text = "Final score: " + ScoreSystem.FinalScore;
    }
}
