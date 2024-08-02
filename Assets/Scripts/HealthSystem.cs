using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public static int health = 100;
    public int currentHealth;
    public EnemyData enemyData;
    public EnemyData goblin;
    public EnemyData bandit;
    public EnemyData ogre;

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
      //  print("health = " + currentHealth);
    }
    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
          /*  switch(enemyData.enemyDamage)
            {
                case goblin:
                    health -= 5;
                    currentHealth = health;
                    break;
                case 2:
                    health -= 10;
                    currentHealth = health;
                    break;
                case 3:
                    health -= 15;
                    currentHealth = health;
                    break;

            }
            
            */
            
            health -= 10;
            currentHealth = health;
           // Debug.Log("currenthealth = " + currentHealth);
        }  
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }
}
