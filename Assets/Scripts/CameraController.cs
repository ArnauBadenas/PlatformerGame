using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 target;
    public PlayerInput player;
    [SerializeField]
    private float speed = 5.0f;

    void Start()
    {
        target = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }

    void Update()
    {
        target.x = player.transform.position.x;
        target.y = player.transform.position.y;

        if (target.x < 0)
        {
            target.y = 0;
        }

        transform.position = target;
    }
}
