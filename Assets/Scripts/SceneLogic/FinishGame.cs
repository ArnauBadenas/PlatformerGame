using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    public static Action OnDeathEvent;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        OnDeathEvent?.Invoke();
        SceneManager.LoadScene("Ending");
    }
}
