using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public void ResetGameToGameplay()
    {
        SceneManager.LoadSceneAsync("Gameplay");
    }
}
