using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("角色属性")]
    public float speed = 200f;
    public float jumpForce = 70f;
    private Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    private PlayerInput playerInput;
    Vector2 moveInput;

    [Header("角色状态")]
    public bool isGrounded = false;
    public float coyoteTime = 0.1f;
    public float coyoteTimeCounter = 0f;

    private void Awake()
    {
        playerInput = new PlayerInput();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        playerInput.Player.Jump.started += Jump;
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void Start()
    {
        
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }
    
    private void Update()
    {
        moveInput = playerInput.Player.Move.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        Move();
        CheckGround();
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveInput.x * speed * Time.fixedDeltaTime, rb.velocity.y);

        // 翻转角色
        if (moveInput.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }

    private void Jump(InputAction.CallbackContext ctx)
    {
        if (isGrounded || coyoteTimeCounter > 0)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    public void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(transform.position - new Vector3(0, 0.4f, 0), 0.05f, LayerMask.GetMask("Ground"));

        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }
    }

}
