using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    float walkSpeed = 5.0f;
    [SerializeField]
    float jumpSpeed = 5.0f;

    Rigidbody2D rb2D;

    InputAction moveAction;
    Vector2 movement;

    [SerializeField]
    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        movement = moveAction.ReadValue<Vector2>();
        animator.SetFloat("Speed", Mathf.Abs(movement.x));
    }

    void FixedUpdate()
    {
        rb2D.linearVelocity = new Vector2(movement.x * walkSpeed, rb2D.linearVelocityY);
    }
}
