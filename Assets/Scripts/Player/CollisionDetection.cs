using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private Transform groundCheckPoint;
    [SerializeField]
    private Transform frontCheckPoint;

    private const float checkRadius = 0.15f;
    
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
        var colliders = Physics2D.OverlapCircleAll(groundCheckPoint.position, checkRadius, groundLayer);
        isGrounded = (colliders.Length > 0);
    }

    private void CheckFront()
    {
        var colliders = Physics2D.OverlapCircleAll(frontCheckPoint.position, checkRadius, groundLayer);
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
