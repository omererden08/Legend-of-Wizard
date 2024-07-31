using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public ExperienceData experience;
    public HealthSystem healthSystem;
    public Transform player;
    private Rigidbody2D rb;
    [SerializeField]
    private float speed = 2f;
    private float rotationSpeed = 200f;
    private float cooldown = 1f;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        healthSystem = FindAnyObjectByType<HealthSystem>(); 
    }

    private void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;  
            rb.velocity = direction * speed;      
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = Mathf.LerpAngle(rb.rotation, angle, rotationSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            healthSystem.TakeDamage();
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (healthSystem.currentHealth > 0)
            {
                if (cooldown < 0)
                {
                    healthSystem.TakeDamage();
                    cooldown = 2f;
                }
                else
                {
                    cooldown -= Time.deltaTime;
                }
            }
            else if (healthSystem.currentHealth <= 0)
            {
                healthSystem.currentHealth = 0;
            }
        }
    }
    private void OnDestroy()
    {
        Instantiate(experience.experiencePrefab, transform.position, Quaternion.identity);
    }
}
