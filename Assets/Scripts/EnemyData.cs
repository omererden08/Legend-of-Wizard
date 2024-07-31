using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewEnemyData", menuName = "Enemy Data", order = 51)]
public class EnemyData : ScriptableObject
{
    public Sprite enemySprite;
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
