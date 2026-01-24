using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource jumpSound;
    [SerializeField]
    private AudioSource deathSound;
    [SerializeField]
    private AudioSource coinSound;

    private void OnEnable()
    {
        PlayerJump.OnJumpChange += SetJumpEffect;
        PlayerLife.OnPlayerDeath += SetDeathEffect;
        Coin.OnCoinCollected += SetCoinEffect;
    }

    private void OnDisable()
    {
        PlayerJump.OnJumpChange -= SetJumpEffect;
        PlayerLife.OnPlayerDeath -= SetDeathEffect;
        Coin.OnCoinCollected -= SetCoinEffect;
    }

    private void SetJumpEffect()
    {
        jumpSound.Play();
    }

    private void SetDeathEffect()
    {
        deathSound.Play();
    }

    private void SetCoinEffect(Coin coin)
    {
        coinSound.Play();
    }
}
