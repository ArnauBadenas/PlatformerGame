using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{

    public void ResetGameToGameplay()
    {
        Debug.Log("RESTART BUTTON CLICKED");
        SceneManager.LoadSceneAsync("Gameplay");
    }
}
