using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float JumpHeight;
    public float PressTimeToMaxJump;
    public float DistanceToMaxHeight;
    public float SpeedHorizontal;

    public Animator Animator;

    public float WallSlideSpeed = 1;
    public ContactFilter2D filter;

    CollisionDetection collisionDetection;
    Rigidbody2D rb2D;
    private float jumpStartedTime;
    private float lastVelocityY;

    private float doubleJumpDelay;
    private bool doubleJumpDone;

    bool isWallSliding => collisionDetection.IsTouchingFront();
    bool isGrounded => collisionDetection.IsGrounded();

    public delegate void OnJumping();
    public static event OnJumping OnJumpChange;

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

        Animator.SetBool("Jump", !isGrounded);
    }

    public void OnJumpStarted()
    {
        if (isGrounded || isWallSliding)
        {
            SetGravity();

            var velocity = new Vector2(rb2D.linearVelocity.x, GetJumpForce());
            rb2D.linearVelocity = velocity;
            jumpStartedTime = Time.time;

            doubleJumpDelay = Time.time + 0.2f;
            doubleJumpDone = false;

            OnJumpChange?.Invoke();
        }

        else if (!doubleJumpDone && Time.time > doubleJumpDelay)
        {
            doubleJumpDone = true;
            var velocity = new Vector2(rb2D.linearVelocity.x, GetJumpForce());
            rb2D.linearVelocity = velocity;

            OnJumpChange?.Invoke();
        }
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
        rb2D.gravityScale *= 1.1f;
    }

    private float GetJumpForce()
    {
        return 2 * JumpHeight * SpeedHorizontal / DistanceToMaxHeight;
    }
}
