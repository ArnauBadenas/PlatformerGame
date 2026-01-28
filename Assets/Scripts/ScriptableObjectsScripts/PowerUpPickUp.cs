using UnityEngine;

public class PowerUpPickUp : MonoBehaviour
{
    [SerializeField]
    private PowerUp effect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerJump>(out _))
        {
            effect.Apply(collision.gameObject);
            gameObject.SetActive(false);
        }
    }
}
