using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour, IPooledObject
{
    private Transform target;
    public Transform player;
    public HealthSystem healthSystem;
    private Rigidbody2D rb;
    [SerializeField]
    private float speed = 5f;
    private float rotationSpeed = 200f;

   // public static event Action OnEnemyDestroyed;


    public void OnObjectSpawn()
    {
        target = FindClosestEnemy();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        healthSystem = FindAnyObjectByType<HealthSystem>();
    }
    private void Update()
    {
        if(target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            rb.velocity = direction * speed;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = Mathf.LerpAngle(rb.rotation, angle, rotationSpeed * Time.fixedDeltaTime);
        }

    }

    Transform FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Transform closest = null;
        float closestDistance = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        if(enemies != null)
        {
            foreach (GameObject enemy in enemies)
            {
                float distance = (enemy.transform.position - currentPosition).sqrMagnitude;
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closest = enemy.transform;
                }
            }
        }
        

        return closest;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            gameObject.SetActive(false);

            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.EnemyTakeDamage(); // Now this should work
            }


            /*  if(EnemyData.instance.currentHealth <= 0)
              {
                  other.gameObject.SetActive(false);

                  ObjectPool.instance.SpawnFromPool("experience", transform.position, Quaternion.identity);
              }
             */

            // other.gameObject.SetActive(false);
            // ObjectPool.instance.SpawnFromPool("experience", transform.position, Quaternion.identity);


        }
    }



}
