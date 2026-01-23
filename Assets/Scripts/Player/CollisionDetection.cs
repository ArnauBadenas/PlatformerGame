using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField] private LayerMask GroundLayer;

    [SerializeField] private Transform GroundCheckPoint;
    [SerializeField] private Transform FrontCheckPoint;

    private float checkRadius = 0.15f;

    [SerializeField] private float distanceToGround;
    [SerializeField] private float groundAngle;

    private bool isGrounded;
    private bool isTouchingFront;

    void FixedUpdate()
    {
        CheckCollisions();
        CheckDistanceTime();
    }

    private void CheckCollisions()
    {
        CheckGrounded();
        CheckFront();
    }

    private void CheckGrounded()
    {
        var colliders = Physics2D.OverlapCircleAll(GroundCheckPoint.position, checkRadius, GroundLayer);
        isGrounded = (colliders.Length > 0);
    }

    private void CheckFront()
    {
        var colliders = Physics2D.OverlapCircleAll(FrontCheckPoint.position, checkRadius, GroundLayer);
        isTouchingFront = (colliders.Length > 0);
    }

    private void CheckDistanceTime()
    {
        RaycastHit2D hit = Physics2D.Raycast(GroundCheckPoint.position, Vector2.down, 100, GroundLayer);

        distanceToGround = hit.distance;
        groundAngle = Vector2.Angle(hit.normal, new Vector2(1, 0));
    }

    public bool IsTouchingFront()
    {
        return isTouchingFront;
    }
}
