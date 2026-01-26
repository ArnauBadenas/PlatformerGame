using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    private Rigidbody2D rigid2d;
    [SerializeField]
    private Animator animator;

    private float horizontalDirection;
    [SerializeField]
    private float speed = 5.0f;

    private bool facingRight = true;

    private void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rigid2d.linearVelocity;
        velocity.x = horizontalDirection * speed;
        rigid2d.linearVelocity = velocity;

        animator.SetFloat("Walk", Mathf.Abs(horizontalDirection));

        if ((horizontalDirection > 0) && !facingRight)
        {
            FlipCharacter();
        }
        else if ((horizontalDirection < 0) && facingRight)
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
