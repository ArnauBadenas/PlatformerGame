using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{
    private Text label;

    private void Awake()
    {
        label = GetComponent<Text>();
    }

    private void OnEnable()
    {
        ScoreSystem.OnScoreUpdated += UpdateText;
    }

    private void OnDisable()
    {
        ScoreSystem.OnScoreUpdated -= UpdateText;
    }

    private void UpdateText(int score)
    {
        label.text = score.ToString();
    }
}
