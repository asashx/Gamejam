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

    [Header("角色攻击")]
    public GameObject meleePrefab;
    private PolygonCollider2D meleeCollider;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public bool canShoot = false;
    private float attackRate = 0.2f;
    private float attackRateCounter = 0f;
    private Vector2 fireDirection = Vector2.zero;
    private Vector2 mousePos;

    private void Awake()
    {
        playerInput = new PlayerInput();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // 获取射击点
        bulletSpawnPoint = transform.Find("Shoot");

        // 获取近战碰撞体
        meleeCollider = meleePrefab.GetComponent<PolygonCollider2D>();

        // 触发跳跃
        playerInput.Player.Jump.started += Jump;

        // 触发射击
        playerInput.Player.Attack.started += Attack;
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
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        fireDirection = mousePos - (Vector2)transform.position;

        attackRateCounter += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Move();
        CheckGround();
    }

    private void Attack(InputAction.CallbackContext ctx)
    {
        if (CanAttack())
        {
            if (canShoot)
            {
                Shoot();
            }
            else
            {
                Melee();
            }
        }
    }

    private bool CanAttack()
    {
        if (attackRateCounter >= attackRate)
        {
            attackRateCounter = 0f;
            return true;
        }
        else
        {
            return false;
        }        
    }

    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        bullet.GetComponent<Bullet>().SetSpeed(fireDirection);
    }

    private void Melee()
    {
        meleeCollider.enabled = true;
        StartCoroutine(DisableMeleeCollider());
    }

    IEnumerator DisableMeleeCollider()
    {
        yield return new WaitForSeconds(0.2f);
        meleeCollider.enabled = false;
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
