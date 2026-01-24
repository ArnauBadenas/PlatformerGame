using UnityEngine;

public class CameraController : MonoBehaviour
{
    Vector3 target;
    [SerializeField]
    private PlayerInput player;

    void Start()
    {
        target = new Vector3(player.transform.position.x, player.transform.position.y, -10);
    }

    void Update()
    {
        target.x = player.transform.position.x;
        target.y = player.transform.position.y;

        transform.position = target;
    }
}
