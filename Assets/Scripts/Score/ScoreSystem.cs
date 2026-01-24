using System;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public int Score = 0;
    public static Action<int> OnScoreUpdated;

    public void OnEnable()
    {
        Coin.OnCoinCollected += UpdateScore;
    }

    public void OnDisable()
    {
        Coin.OnCoinCollected -= UpdateScore;
    }

    private void UpdateScore(Coin coin)
    {
        Score += coin.Value;
        OnScoreUpdated?.Invoke(Score);
    }
}
