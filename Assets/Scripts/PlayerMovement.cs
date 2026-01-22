using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerInput : MonoBehaviour
{
    Rigidbody2D rb2D;
    [SerializeField] Animator animator;

    float horizontalDirection;
    [SerializeField] float speed = 5.0f;

    bool facingRight = true;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 velocity = rb2D.linearVelocity;
        velocity.x = horizontalDirection * speed;
        rb2D.linearVelocity = velocity;
        
        animator.SetFloat("Walk", Mathf.Abs(horizontalDirection));

        if (horizontalDirection > 0 && !facingRight)
        {
            FlipCharacter();
        } else if (horizontalDirection < 0 && facingRight)
        {
            FlipCharacter();
        }
    }

    void OnMove(InputValue value)
    {
        var input = value.Get<Vector2>();
        horizontalDirection = input.x;
    }

    void FlipCharacter()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
