using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public int Value;
    public static Action<Coin> OnCoinCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnCoinCollected?.Invoke(this);
        Destroy(gameObject);
    }
}
