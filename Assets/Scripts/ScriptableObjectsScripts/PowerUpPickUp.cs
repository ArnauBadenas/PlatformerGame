using System.Collections;
using UnityEngine;

public class PowerUpPickUp : MonoBehaviour
{
    [SerializeField]
    private PowerUp effect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerJump>(out PlayerJump player))
        {
            // Coroutine to remove the effect without stopping the game, done to the player because the power up will be deactivated.
            _ = player.StartCoroutine(ApplyAndRemove(collision.gameObject));
            gameObject.SetActive(false);
        }

    }

    private IEnumerator ApplyAndRemove(GameObject target) //Ienumerator para usar corrutina
    {
        effect.Apply(target);
        yield return new WaitForSeconds(effect.Duration);
        effect.Remove(target);
    }
}

