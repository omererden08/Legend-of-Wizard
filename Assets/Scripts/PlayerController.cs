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
    [SerializeField] private float accelerationSpeed;
    [SerializeField] private float maxSpeed;
    //Dash
    /* [SerializeField] private float dashingTime;
     [SerializeField] private float dashingCooldown;
     [SerializeField] private float dashingPower;
     private Vector3 dashDirection;
     public bool canDash = true;
     public bool isDashing;
    */
    public ExperienceSystem experienceSystem;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        speed = 0;
    }
    private void Update()
    {
        ManageSpeed();

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
    void ManageSpeed()
    {
        if (verticalInput != 0 || horizontalInput != 0 && speed < maxSpeed)
        {
            speed += accelerationSpeed * Time.deltaTime;
        }
        else if (verticalInput == 0 || horizontalInput == 0)
        {
            speed -= accelerationSpeed * Time.deltaTime;
        }
        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
        else if (speed < 0)
        {
            speed = 0;
        }
    }
    void HandleMovement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        Vector2 moveDirection = new Vector2(horizontalInput, verticalInput);
        rb.velocity = moveDirection * speed * Time.fixedDeltaTime;

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
            experienceSystem.HandleExperienceChange();
        }
    }


}
