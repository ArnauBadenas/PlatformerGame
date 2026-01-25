using System.Collections;
using UnityEngine;


public class PowerupPickup : MonoBehaviour
{
    [SerializeField] private Powerup effect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerJump>(out PlayerJump player))
        {
            //Corrutina para poder remover el efecto al cabo de la duración del efecto sin parar el juego
            //Aplico la corrutina al player porque "this" (el powerup) se desactiva, entonces la corrutina no se continuaria.
            _ = player.StartCoroutine(ApplyAndRemove(collision.gameObject));
            gameObject.SetActive(false); // Quitar el powerup
        }

    }

    private IEnumerator ApplyAndRemove(GameObject target) //Ienumerator para usar corrutina
    {
        effect.Apply(target);
        yield return new WaitForSeconds(effect.duration);
        effect.Remove(target);
    }
}

