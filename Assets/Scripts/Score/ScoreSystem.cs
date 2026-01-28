using System;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int Score = 0;
    public static int FinalScore = 0;

    public static event Action<int> OnScoreUpdated;

    public void OnEnable()
    {
        Coin.OnCoinCollected += UpdateScore;
        FinishGame.OnDeathEvent += WriteFinalScore;
        FinishGame.OnFinishedEvent += WriteFinalScore;
    }

    public void OnDisable()
    {
        Coin.OnCoinCollected -= UpdateScore;
        FinishGame.OnDeathEvent -= WriteFinalScore;
        FinishGame.OnFinishedEvent -= WriteFinalScore;
    }

    private void UpdateScore(Coin coin)
    {
        Score += coin.Value;
        OnScoreUpdated?.Invoke(Score);
    }

    private void WriteFinalScore()
    {
        FinalScore = Score;
    }
}
