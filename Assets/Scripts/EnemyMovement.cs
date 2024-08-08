using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour, IPooledObject
{
    public ExperienceData experience;
    public HealthSystem healthSystem;
    public Transform player;
    private Rigidbody2D rb;
    [SerializeField]
    private float speed = 2f;
    private float rotationSpeed = 200f;


    public void OnObjectSpawn()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        healthSystem = FindAnyObjectByType<HealthSystem>();
        rb.mass = 0;
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
}
