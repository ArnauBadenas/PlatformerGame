using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
    public static event Action OnDeathEvent; // Action for the player dying before they reach the end
    public static event Action OnFinishedEvent; // Action for the player finishing the game

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.CompareTag("Spike") || gameObject.CompareTag("DeathDetector"))
        {
            StartCoroutine(BreakBetweenScenes());
        }

        else
        {
            OnFinishedEvent?.Invoke();
            ChangeScene();
        }
    }

    private IEnumerator BreakBetweenScenes()
    {
        OnDeathEvent?.Invoke();
        yield return new WaitForSecondsRealtime(0.75f);
        ChangeScene();
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("Ending");
    }
}
