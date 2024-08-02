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
    private float cooldown = 1f;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }
    private void Update()
    {

      /*  if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Dash());
        }*/
    }
    private void FixedUpdate()
    {
       /* if (isDashing)
        {
            return;   
        }*/
        HandleMovement();
    }
    
    void HandleMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);
        rb.velocity = moveDirection * speed * Time.deltaTime;

        if (moveDirection.magnitude > 1)
        {
            moveDirection.Normalize();
        }


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
            Destroy(other.gameObject);
            ExperienceSystem.instance.HandleExperienceChange();
            print("a");
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            HealthSystem.instance.TakeDamage();
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
                    HealthSystem.instance.TakeDamage();
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
}
