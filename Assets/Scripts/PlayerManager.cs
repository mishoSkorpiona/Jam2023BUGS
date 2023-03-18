using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private Vector2 moveDirection;
    public float maxSpeed = 5f;

    public float groundDistance = 0.5f;
    bool grounded;
    public int amountOfJumps = 1;
    int jumpsRemaining;
    float lastGroundedJumpTime;
    float jumpGroundedIgnoreTime = 0.2f;

    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float jumpForce = 5;
    [SerializeField] private float jumpStaling = 0.65f;
    

    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float health = 120;
    public int playerIndex;

    [SerializeField] private int baseDamage = 10; // attacks are a scale of that number 

    [Header("North Attack")]
    [SerializeField] private Collider2D[] northAttackCollider;
    [SerializeField] private float northAttackKnockbackPower = 10;
    [SerializeField] private float northAttackDamage = 10;
    [SerializeField] private float northAttackStun = 10;

    
    
    [Header("South Attack")]
    [SerializeField] private Collider2D[] southAttackCollider;
    [SerializeField] private float southAttackKnockbackPower = 10;
    [SerializeField] private float southAttackDamage = 10;
    [SerializeField] private float southAttackStun = 10;
    
    
    [Header("East Attack")]
    [SerializeField] private Collider2D[] eastAttackCollider;
    [SerializeField] private float eastAttackKnockbackPower = 10;
    [SerializeField] private float eastAttackDamage = 10;
    [SerializeField] private float eastAttackStun = 10;
    
    [Header("West Attack")]
    [SerializeField] private Collider2D[] westAttackCollider;
    [SerializeField] private float westAttackKnockbackPower = 10;
    [SerializeField] private float westAttackDamage = 10;
    [SerializeField] private float westAttackStun = 10;
    
    

    // Start is called before the first frame update
    void Start()
    {
        // Disable all attack colliders at the start
        //northAttackCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        HandleMovement();
    }

    void HandleMovement()
    {
        _rigidbody2D.AddForce(moveDirection * moveSpeed * Time.deltaTime);

        //limit thier horizontal speed
        float horizontalSpeed = _rigidbody2D.velocity.x;
        if (Mathf.Abs(horizontalSpeed) > maxSpeed)
            _rigidbody2D.velocity = _rigidbody2D.velocity * Vector2.up + maxSpeed * Mathf.Sign(horizontalSpeed) * Vector2.right;

        // Flip the player based on movement direction
        if (moveDirection.x > 0.1)
        {
            Vector3 newRotation = new Vector3(0, 0, 0);
            transform.eulerAngles = newRotation;
            
        }
        else if (moveDirection.x < -0.1)
        {
            Vector3 newRotation = new Vector3(0, 180, 0);
            transform.eulerAngles = newRotation;
            
        }

        grounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, 1);

        //the timer in here is to make sure it doesn't think we're grounded while we're jumping off the ground
        if (grounded && Time.time > lastGroundedJumpTime + jumpGroundedIgnoreTime) jumpsRemaining = amountOfJumps;
    }

    void OnMove(InputValue input)
    {
        moveDirection = input.Get<Vector2>();
        moveDirection = new Vector2(moveDirection.x, 0);
    }

    void OnJump()
    {
        if (jumpsRemaining <= 0) return;

        float currentStaling = Mathf.Pow(jumpStaling, amountOfJumps - jumpsRemaining);
        _rigidbody2D.AddForce(Vector2.up * jumpForce * currentStaling, ForceMode2D.Impulse);
        jumpsRemaining--;
        
        if (grounded) lastGroundedJumpTime = Time.time;
    }

    void OnShield()
    {
        

    }


    void OnAttackNorth()
    {
        HandleAttack(northAttackCollider);
    }


    void OnAttackSouth()
    {
        HandleAttack(southAttackCollider);
    }
    
    
    void OnAttackEast()
    {
        HandleAttack(eastAttackCollider);
    }


    void OnAttackWest()
    {
        HandleAttack(westAttackCollider);
    }


    
    void HandleAttack(Collider2D[] colliders)
    {
        // Enable the attack collider(s)
        foreach (Collider2D collider in colliders)
        {
            collider.enabled = true;
        }

        // Check which enemy was hit by the collider(s)
        Collider2D[] hitEnemies = new Collider2D[10];
        ContactFilter2D filter = new ContactFilter2D();
        filter.useTriggers = true;

        int numColliders = Physics2D.OverlapCollider(colliders[^1], filter, hitEnemies);
        for (int i = 0; i < numColliders; i++)
        {
            Collider2D enemyCollider = hitEnemies[i];
            if (hitEnemies[i].gameObject == this.gameObject) continue;

            PlayerManager enemy = enemyCollider.GetComponent<PlayerManager>();
            if (enemy != null)
            {
                // Calculate knockback direction and power
                ColliderData colliderData = colliders[^1].GetComponent<ColliderData>();
                Vector2 knockbackDirection = Quaternion.Euler(0, 0, colliderData.knockbackDirection) * Vector2.up;
                float knockbackPower = colliderData.knockbackPower;

                // Apply knockback to the enemy
                enemy.ApplyKnockback(knockbackDirection, knockbackPower);

                // Apply damage to the enemy
                float damage = baseDamage * colliderData.damagePercentage;
                enemy.TakeDamage(damage);

                // Apply stun to the enemy
                float stunDuration = colliderData.stunDuration;
                enemy.ApplyStun(stunDuration);
            }
        }

        // Disable the attack collider(s)
        foreach (Collider2D collider in colliders)
        {
            collider.enabled = false;
        }
    }



    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    public void ApplyStun(float stunTime)
    {
        
    }

    public void ApplyKnockback(Vector2 direction, float power)
    {
        _rigidbody2D.AddForce(direction *  power, ForceMode2D.Impulse);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * groundDistance);
    }
}