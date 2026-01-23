using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float JumpHeight;
    public float PressTimeToMaxJump;
    public float DistanceToMaxHeight;
    public float SpeedHorizontal;

    [SerializeField]
    public Animator Animator;

    public float WallSlideSpeed = 1;
    public ContactFilter2D filter;

    CollisionDetection collisionDetection;
    Rigidbody2D rb2D;
    private float jumpStartedTime;
    private float lastVelocityY;
    private float jumpsCount = 0;
    public float doubleJumpDelay;
    public bool doubleJumpDone;

    bool isWallSliding => collisionDetection.IsTouchingFront();
    bool isGrounded => collisionDetection.IsGrounded();

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
        if (isGrounded || isWallSliding)
        {
            SetGravity();

            var velocity = new Vector2(rb2D.linearVelocity.x, GetJumpForce());
            rb2D.linearVelocity = velocity;
            jumpStartedTime = Time.time;

            doubleJumpDelay = Time.time + 0.3f;
            doubleJumpDone = false;

            Animator.SetBool("Jump", true);
        }

        else if (!doubleJumpDone && Time.time > doubleJumpDelay)
        {
            doubleJumpDone = true;
            var velocity = new Vector2(rb2D.linearVelocity.x, GetJumpForce());
            rb2D.linearVelocity = velocity;

            Animator.SetBool("Jump", true);
        }
    }

    public void OnJumpFinished()
    {
        float fractionOfTimePassed = 1 / Mathf.Clamp01((Time.time - jumpStartedTime) / PressTimeToMaxJump);
        rb2D.gravityScale *= fractionOfTimePassed;

        Animator.SetBool("Jump", false);
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
