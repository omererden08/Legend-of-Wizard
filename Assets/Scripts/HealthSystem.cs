using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public static int health = 100;
    public int currentHealth;

    private void Start()
    {
        currentHealth = health;
      //  print("health = " + currentHealth);
    }
    public void TakeDamage()
    {
        if (currentHealth > 0)
        {
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
