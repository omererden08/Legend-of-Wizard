using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public static int health = 100;
    public int currentHealth;
    public EnemyData enemyData;
    private int damage;
    public static HealthSystem instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(instance.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    private void Start()
    {
        currentHealth = health;
        damage = enemyData.enemyDamage;
        print("current health = " + currentHealth);
    }
    public void PlayerTakeDamage()
    {
        if (currentHealth > 0)
        {
            health -= damage;
            currentHealth = health;
            print("current health = " + currentHealth);
        }
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            print("died");
        }
    }
}
