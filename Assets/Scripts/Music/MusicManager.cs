using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    AudioSource jumpSound;
    [SerializeField]
    AudioSource deathSound;

    private void OnEnable()
    {
        PlayerJump.OnJumpChange += SetJumpEffect;
        PlayerLife.OnPlayerDeath += SetDeathEffect;
    }

    private void OnDisable()
    {
        PlayerJump.OnJumpChange -= SetJumpEffect;
        PlayerLife.OnPlayerDeath -= SetDeathEffect;
    }

    private void SetJumpEffect()
    {
        jumpSound.Play();
    }

    private void SetDeathEffect()
    {
        deathSound.Play();
    }
}
