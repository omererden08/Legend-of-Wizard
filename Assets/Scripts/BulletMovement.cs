using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Transform enemyPos;
    public Transform player;
    public HealthSystem healthSystem;
    private Rigidbody2D rb;
    private float speed = 3f;

    public static event Action OnEnemyDestroyed;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyPos = GameObject.FindGameObjectWithTag("Enemy").transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        healthSystem = FindAnyObjectByType<HealthSystem>();
    }
    private void FixedUpdate()
    {
        if(enemyPos != null)
        {
            //spawnpos kamera içinde olacak þekilde ayarla
            Vector2 direction = (enemyPos.transform.position - transform.position).normalized;
            rb.velocity = direction * speed;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            OnEnemyDestroyed?.Invoke();
        }
    }



}
