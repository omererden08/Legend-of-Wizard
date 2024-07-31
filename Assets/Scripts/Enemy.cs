using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyData enemyData;

    private int currentHealth;
    private int currentDamage;
    private float currentSpeed;


    private void Start()
    {
        if(enemyData != null)
        {
            currentHealth = enemyData.enemyHealth;
            currentDamage = enemyData.enemyDamage;
            currentSpeed = enemyData.enemySpeed;
        }
    }

    void EnemyTakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}

