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
        Coin.OnCoinCollected += SetCoinEffect;
        FinishGame.OnDeathEvent += SetDeathEffect;
    }

    private void OnDisable()
    {
        PlayerJump.OnJumpChange -= SetJumpEffect;
        Coin.OnCoinCollected -= SetCoinEffect;
        FinishGame.OnDeathEvent -= SetDeathEffect;
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
