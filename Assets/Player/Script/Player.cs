using UnityEngine;

//public class Player : MonoBehaviour
//{
//    public float speed = 5f;
//    public float jumpForce = 2f;
//    public Transform groundCheck;
//    public LayerMask groundLayer;
//    public float groundCheckDistance = 0.1f;
//    public float attackCooldown = 0.5f; // Cooldown time between attacks

//    private Rigidbody2D rb;
//    private Animator animator;
//    private bool isGrounded;
//    private bool isAttacking;
//    private float lastAttackTime;

//    void Start()
//    {
//        rb = GetComponent<Rigidbody2D>();
//        animator = GetComponent<Animator>();
//    }

//    void Update()
//    {
//        HandleInput();
//        UpdateAnimations();
//        CollisionCheck();
//    }

//    void FixedUpdate()
//    {
//        HandleMovement();
//    }

//    void HandleInput()
//    {
//        // Horizontal movement
//        float horizontalInput = Input.GetAxis("Horizontal");
//        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

//        // Jumping
//        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
           
//        {
//            Jump();
//        }

//        // Attack
//        if (Input.GetMouseButtonDown(0) && !isAttacking && Time.time - lastAttackTime > attackCooldown)
//        {
//            Attack();
//        }
//    }

//    void HandleMovement()
//    {
//        // Flip the player based on the direction of movement
//        if (rb.velocity.x > 0.1f)
//        {
//            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
//        }
//        else if (rb.velocity.x < -0.1f)
//        {
//            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f); // Flip the scale for left movement
//        }
//    }

//    void Jump()
//    {
//        rb.velocity = new Vector2(rb.velocity.x, 0f); // Reset vertical velocity before jumping
//        rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
//        isGrounded = false;
//    }

//    void Attack()
//    {
//        isAttacking = true;
//        lastAttackTime = Time.time;
//        animator.SetTrigger("Attack");
//    }

//    public void EndAttack()
//    {
//        isAttacking = false;
//    }

//    void UpdateAnimations()
//    {
//        // Update animator parameters based on player's state
//        animator.SetFloat("Speed", Mathf.Abs(rb.velocity.x));
//        animator.SetBool("isGrounded", isGrounded);
//        animator.SetBool("isAttacking", isAttacking); // Add this line if you have an "isAttacking" parameter in your animator
//    }

//    public void CollisionCheck()
//    {
//        isGrounded = Physics2D.Raycast(groundCheck.transform.position, Vector2.down, groundCheckDistance, groundLayer);
//    }

//    public void OnDrawGizmos()
//    {
//        Gizmos.DrawLine(groundCheck.transform.position, new Vector3(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
//    }
//}

