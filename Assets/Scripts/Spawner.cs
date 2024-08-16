using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    public GameObject[] enemyPrefabs;
    public GameObject bulletPrefab;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, 2f);
        InvokeRepeating("SpawnEnemy2", 1f, 2f);
      //  InvokeRepeating("SpawnProjectile", 2.5f, 1f);
      //  Invoke("SpawnEnemy", 1f); //testing*/
       // Invoke("SpawnEnemy2", 1f); //testing*/
    }
    
    Vector2 SpawnPos1()
    {
        float randomX = (Random.Range(0, 2) == 0) ? player.position.x + 13 : player.position.x - 13;
        float randomY = (Random.Range(-10, 10));

        Vector2 randomPos = new Vector2(randomX, randomY);
        return randomPos;
    }
    
    Vector2 SpawnPos2()
    {
        float randomX = (Random.Range(-13, 13));
        float randomY = (Random.Range(0, 2) == 0) ? player.position.y + 10 : player.position.y - 10;

        Vector2 randomPos = new Vector2(randomX, randomY);
        return randomPos;
    }

    private void FixedUpdate()
    {
       // SpawnEnemy();
    }


    void SpawnEnemy()
    {
       
       // ObjectPool.instance.SpawnFromPool("enemy1", SpawnPos1(), Quaternion.identity);
       // ObjectPool.instance.SpawnFromPool("enemy2", SpawnPos2(), Quaternion.identity);
        ObjectPool.instance.SpawnFromPool("enemy3", SpawnPos1(), Quaternion.identity);
      
    }

    void SpawnEnemy2()
    {
        
        ObjectPool.instance.SpawnFromPool("enemy1", SpawnPos1(), Quaternion.identity);
       // ObjectPool.instance.SpawnFromPool("enemy2", SpawnPos2(), Quaternion.identity);
       // ObjectPool.instance.SpawnFromPool("enemy3", SpawnPos1(), Quaternion.identity);

    }

    void SpawnProjectile()
    {  
        ObjectPool.instance.SpawnFromPool("projectile", player.position, Quaternion.identity);
    }
}
