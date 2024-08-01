using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu]
public class EnemyData : ScriptableObject
{
    public string enemyName; 
    public int enemyHealth; 
    public int enemyDamage;
    public float enemySpeed;


    public EnemyData(string enemyName, int enemyHealth, int enemyDamage, float enemySpeed)
    {
        this.enemyName = enemyName;
        this.enemyHealth = enemyHealth;
        this.enemyDamage = enemyDamage;
        this.enemySpeed = enemySpeed;
    }
}
