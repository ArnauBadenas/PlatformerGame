using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float JumpHeight;
    public float PressTimeToMaxJump;
    public float DistanceToMaxHeight;
    public float SpeedHorizontal;

    public float WallSlideSpeed = 1;
    public ContactFilter2D filter;

    CollisionDetection collisionDetection;
    Rigidbody2D rb2D;
    private float jumpStartedTime;
    private float lastVelocityY;

    bool isWallSliding => collisionDetection.IsTouchingFront();

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        collisionDetection = GetComponent<CollisionDetection>();
    }

    private void FixedUpdate()
    {
        if (IsPeakReached())
        {
            ChangeGravity();
        }

        if (isWallSliding)
        {
            SetWallSlide();
        }
    }

    public void OnJumpStarted()
    {
        SetGravity();

        var velocity = new Vector2(rb2D.linearVelocity.x, GetJumpForce());
        rb2D.linearVelocity = velocity;
        jumpStartedTime = Time.time;
    }

    public void OnJumpFinished()
    {
        float fractionOfTimePassed = 1 / Mathf.Clamp01((Time.time - jumpStartedTime) / PressTimeToMaxJump);
        rb2D.gravityScale *= fractionOfTimePassed;
    }

    private bool IsPeakReached()
    {
        bool reached = ((lastVelocityY * rb2D.linearVelocity.y) < 0);
        lastVelocityY = rb2D.linearVelocity.y;

        return reached;
    }

    private void SetWallSlide()
    {
        rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, Mathf.Max(rb2D.linearVelocity.y, -WallSlideSpeed));
    }

    private void SetGravity()
    {
        var gravity = 2 * JumpHeight * (SpeedHorizontal * SpeedHorizontal) / (DistanceToMaxHeight * DistanceToMaxHeight);
        rb2D.gravityScale = gravity / 9.81f;
    }

    private void ChangeGravity()
    {
        rb2D.gravityScale *= 1.2f;
    }

    private float GetJumpForce()
    {
        return 2 * JumpHeight * SpeedHorizontal / DistanceToMaxHeight;
    }

    private float GetDistanceToGround()
    {
        RaycastHit2D[] hit = new RaycastHit2D[3];
        Physics2D.Raycast(transform.position, Vector2.down, filter, hit, 10);

        return hit[0].distance;
    }
}
