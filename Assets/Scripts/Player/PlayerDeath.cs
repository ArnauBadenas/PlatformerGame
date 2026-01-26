using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Animator Animator;

    public void Awake()
    {
        Animator = GetComponent<Animator>();
    }

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
