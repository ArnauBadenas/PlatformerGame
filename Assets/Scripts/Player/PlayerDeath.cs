using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Animator Animator;

    private void OnEnable()
    {
        FinishGame.OnDeathEvent += ShowDeathAnimation;
    }

    private void OnDisable()
    {
        FinishGame.OnDeathEvent -= ShowDeathAnimation;
    }

    private void ShowDeathAnimation()
    {
        Animator.SetBool("Dead", true);
    }
}
