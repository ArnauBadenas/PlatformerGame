using UnityEngine;

public class DeathDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        IKillable killable = collision.GetComponent<IKillable>();
        killable?.Die();
    }
}
