using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    //Movement
    private Rigidbody2D rb;
    private float horizontalInput;
    private float verticalInput;
    [SerializeField] private float speed;

    //Dash
    /* [SerializeField] private float dashingTime;
     [SerializeField] private float dashingCooldown;
     [SerializeField] private float dashingPower;
     private Vector3 dashDirection;
     public bool canDash = true;
     public bool isDashing;
    */
    //Animation
    private Animator animator;
    private Collider2D colliderPlayer;
    Quaternion targetRotation;
    [SerializeField]private bool isRight;
    private bool isMoving;

    Enemy enemy;
    HealthSystem player;
    private float cooldown = 1f;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
        animator = GetComponent<Animator>();
        colliderPlayer = GetComponent<Collider2D>();
        isRight = false;
    }
    private void Update()
    {
        CheckRotation();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }


    void HandleMovement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);
        rb.velocity = moveDirection * speed * Time.fixedDeltaTime;
        MoveAnimation();

        /* if(moveDirection != Vector3.zero)
         {
             dashDirection = moveDirection;
         }*/
    }
    /* private IEnumerator Dash()
     {
         canDash = false;
         isDashing = true;
         rb.velocity = dashDirection * dashingPower;
         yield return new WaitForSeconds(dashingTime);
         isDashing = false;
         yield return new WaitForSeconds(dashingCooldown);
         canDash = true;
     } */
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Exp"))
        {
            other.gameObject.SetActive(false);
            //Destroy(other.gameObject);
            ExperienceSystem.instance.HandleExperienceChange();
            print("a");
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemy = other.gameObject.GetComponent<Enemy>();
            enemy.AttackPlayer(player);
        }
    }
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            if (HealthSystem.instance.currentHealth > 0)
            {
                if (cooldown < 0)
                {
                    enemy = other.gameObject.GetComponent<Enemy>();
                    enemy.AttackPlayer(player);
                    cooldown = 2f;
                }
                else
                {
                    cooldown -= Time.deltaTime;
                }
            }
            else if (HealthSystem.instance.currentHealth <= 0)
            {
                HealthSystem.instance.currentHealth = 0;
            }
        }
    } 
    void MoveAnimation()
        
    {
        bool isMovingRight = rb.velocity.x > 0;
        bool isMovingLeft = rb.velocity.x < 0;
        bool isNotMovingHorizontal = rb.velocity.x == 0;
        bool isMovingUp = rb.velocity.y > 0;
        bool isMovingDown = rb.velocity.y < 0;
        bool isNotMovingVertical = rb.velocity.y == 0;

        if (isMovingRight)
        {
            isRight = true;
        }
        else if (isMovingLeft)
        {
            isRight = false;
        }

        switch (true)
        {
            case bool _ when isMovingRight || (isMovingUp && isRight) || (isMovingDown && isRight):
                animator.SetBool("MoveRight", true);
                animator.SetBool("MoveLeft", false);
                break;

            case bool _ when isMovingLeft || (isMovingUp && !isRight) || (isMovingDown && !isRight):
                animator.SetBool("MoveLeft", true);
                animator.SetBool("MoveRight", false);
                break;

            case bool _ when isNotMovingHorizontal && isRight:
                animator.SetBool("MoveRight", false);
                animator.SetBool("MoveLeft", false);
                break;

            case bool _ when isNotMovingHorizontal && !isRight:
                animator.SetBool("MoveLeft", false);
                animator.SetBool("MoveRight", false);
                break;

            case bool _ when isNotMovingVertical && isRight:
                animator.SetBool("MoveRight", false);
                animator.SetBool("MoveLeft", false);
                break;

            case bool _ when isNotMovingVertical && !isRight:
                animator.SetBool("MoveLeft", false);
                animator.SetBool("MoveRight", false);
                break;
        }

    }
    void CheckRotation()
    {
        if (!isRight)
        {
            targetRotation = Quaternion.Euler(colliderPlayer.transform.eulerAngles.x, 0, colliderPlayer.transform.eulerAngles.z);
        }
        if (isRight)
        {
            targetRotation = Quaternion.Euler(colliderPlayer.transform.eulerAngles.x, -180, colliderPlayer.transform.eulerAngles.z);
        }
        colliderPlayer.transform.rotation = targetRotation;
    }


}

