using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour, IPooledObject
{
    public HealthSystem healthSystem;
    public EnemyData enemyData;
    public Transform player;
    private Rigidbody2D rb;
    [SerializeField]
    private float speed = 2f;
    private float rotationSpeed = 200f;
    private int health;
    public int bulletDamage;

    public void OnObjectSpawn()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        healthSystem = FindAnyObjectByType<HealthSystem>();
        rb.mass = 0;
        bulletDamage = 20;
        health = enemyData.enemyHealth;
    }

    private void FixedUpdate()
    {
         if (player != null)
         {
             Vector2 direction = (player.position - transform.position).normalized;  
             rb.velocity = direction * speed * Time.fixedDeltaTime;      
             float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
             rb.rotation = Mathf.LerpAngle(rb.rotation, angle, rotationSpeed * Time.fixedDeltaTime);
         } 
    }

    public void EnemyTakeDamage()
    {
        if(health > 0)
        {
            health -= bulletDamage;
           
        }
        else if(health <= 0)
        {
            health = 0;
            gameObject.SetActive(false);
            
        }
    }


}
