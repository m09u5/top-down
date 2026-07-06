using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
   [SerializeField]private float walkSpeed = 2f;
   [SerializeField]private float sprintSpeed = 10f;
   
   public float WalkSpeed => walkSpeed;
   public float SprintSpeed => sprintSpeed;
   
   private float currentSpeed;
   private Rigidbody2D rb;
   private Vector2 moveInput;
   private Animator animator;

    void Start()
    {
        currentSpeed = walkSpeed;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        rb.linearVelocity = moveInput * currentSpeed;
    }
    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("IsWalking", true);
        if (context.canceled)
        {
            animator.SetBool("IsWalking", false);
            animator.SetFloat("LastInputX", moveInput.x);
            animator.SetFloat("LastInputY", moveInput.y);
        }

        moveInput = context.ReadValue<Vector2>();
        animator.SetFloat("InputX", moveInput.x);
        animator.SetFloat("InputY", moveInput.y);

    }
    public void Sprint(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            currentSpeed = sprintSpeed;
        }
        else if (context.canceled)
        {
            currentSpeed = walkSpeed;
        }

    }
}
