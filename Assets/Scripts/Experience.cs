using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Experience : MonoBehaviour
{
    private Transform target;
    private float collectDistance;
    private float maxSpeed;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float accelerationSpeed;
    private Rigidbody2D rb;
    private bool isRange;
    private float rotationSpeed = 200f;


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
        rb = GetComponent<Rigidbody2D>();
        
        collectDistance = 2.5f;
        
        speed = 0f;
       
        maxSpeed = 20f;
    }


    private void FixedUpdate()
    {
        if(rb != null)
        {
            float distance = Vector2.Distance(target.position, transform.position);

            if (distance < collectDistance)
            {
                isRange = true;
            }
            if (isRange == true)
            {
                Vector2 direction = (target.position - transform.position);

                direction.Normalize();

                if (speed < maxSpeed)
                {
                    speed += accelerationSpeed * Time.fixedDeltaTime;
                }

                else if (speed >= maxSpeed)
                {
                    speed = maxSpeed;
                }

                rb.velocity += direction * speed * Time.fixedDeltaTime;

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                rb.rotation = Mathf.LerpAngle(rb.rotation, angle, rotationSpeed * Time.fixedDeltaTime);
            } 
        }     
    }
}
