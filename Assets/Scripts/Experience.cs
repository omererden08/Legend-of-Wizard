using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Experience : MonoBehaviour
{
    private Transform target;
    private float collectDistance;
    private float maxSpeed;
    private float speed;
    private Rigidbody2D rb;
    private float rotationSpeed = 200f;


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        collectDistance = 2.5f;
        speed = 20f;
        maxSpeed = 100f;
    }


    private void FixedUpdate()
    {
        if(rb != null)
        {
            float distance = Vector2.Distance(target.position, transform.position);


            if (distance < collectDistance && maxSpeed > speed)
            {
                Vector2 direction = (target.position - transform.position).normalized;

                rb.velocity += direction * speed * Time.fixedDeltaTime;

                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                rb.rotation = Mathf.LerpAngle(rb.rotation, angle, rotationSpeed * Time.fixedDeltaTime);

            }
        }     
    }
}
