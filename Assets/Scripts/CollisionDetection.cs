using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField]
    private LayerMask GroundLayer;

    [SerializeField]
    private Transform GroundCheckPoint;
    [SerializeField]
    private Transform FrontCheckPoint;

    private float checkRadius = 0.15f;

    private bool isGrounded;
    private bool isTouchingFront;

    void FixedUpdate()
    {
        CheckCollisions();
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

    public bool IsTouchingFront()
    {
        return isTouchingFront;
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }
}
