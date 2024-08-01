using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour
{
    private Transform target;
    private float collectDistance;
    private float speed;
    private Rigidbody2D rb;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        collectDistance = 2.5f;
        speed = 2.5f;
    }


    private void Update()
    {
        float distance = Vector2.Distance(target.position, transform.position);


        if (distance < collectDistance)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            rb.velocity = direction * speed;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }
    }
}
