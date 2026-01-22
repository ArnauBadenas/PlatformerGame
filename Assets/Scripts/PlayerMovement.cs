using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerInput : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [SerializeField]
    private Animator animator;

    private float horizontalDirection;
    [SerializeField]
    private float speed = 5.0f;

    private bool facingRight = true;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb2D.linearVelocity;
        velocity.x = horizontalDirection * speed;
        rb2D.linearVelocity = velocity;

        animator.SetFloat("Walk", Mathf.Abs(horizontalDirection));

        if (horizontalDirection > 0 && !facingRight)
        {
            FlipCharacter();
        }
        else if (horizontalDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();
        horizontalDirection = input.x;
    }

    private void FlipCharacter()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
