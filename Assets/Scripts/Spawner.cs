using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    public float minRadius;
    public float maxRadius;
    public GameObject[] enemyPrefabs;
    public GameObject bulletPrefab;

    private void Start()
    {
        InvokeRepeating("SpawnProjectile", 2.5f, 1f);
        InvokeRepeating("GoblinSpawner", 1f, 1f); 
    }

    private void Update()
    {
        transform.position = player.position;
    }

    Vector2 spawnPos()
    {
        float randomAngle = Random.Range(0f, 360f);

        float randomRadius = Random.Range(minRadius, maxRadius);

        Vector2 randomPoint = new Vector2(
            Mathf.Cos(randomAngle * Mathf.Deg2Rad) * randomRadius,
            Mathf.Sin(randomAngle * Mathf.Deg2Rad) * randomRadius
        );

        Vector3 spawnPosition = player.position + new Vector3(randomPoint.x, randomPoint.y, 0);

        return spawnPosition;
    }


    void GoblinSpawner()
    {        
        ObjectPool.instance.SpawnFromPool("enemy1", spawnPos(), Quaternion.identity);
    }
    void BanditSpawner()
    {        
        ObjectPool.instance.SpawnFromPool("enemy2", spawnPos(), Quaternion.identity);
    }
    void OgreSpawner()
    {        
        ObjectPool.instance.SpawnFromPool("enemy3", spawnPos(), Quaternion.identity);
    }


    public void SpawnGoblin()
    {
        InvokeRepeating("GoblinSpawner", 1f, 2f);
    }
    public void SpawnBandit()
    {
        InvokeRepeating("BanditSpawner", 1f, 2f);
    }
    public void SpawnOgre()
    {
        InvokeRepeating("OgreSpawner", 1f, 2f);
    }




    /*   Vector2 SpawnPos1()
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


       

       public void SpawnEnemy1()
       {    
           ObjectPool.instance.SpawnFromPool("enemy1", SpawnPos1(), Quaternion.identity);
           ObjectPool.instance.SpawnFromPool("enemy1", SpawnPos2(), Quaternion.identity);
       }

       public void SpawnEnemy2()
       {
           ObjectPool.instance.SpawnFromPool("enemy2", SpawnPos1(), Quaternion.identity);
           ObjectPool.instance.SpawnFromPool("enemy2", SpawnPos2(), Quaternion.identity);
       }
       public void SpawnEnemy3()
       {
           ObjectPool.instance.SpawnFromPool("enemy3", SpawnPos1(), Quaternion.identity);
           ObjectPool.instance.SpawnFromPool("enemy3", SpawnPos2(), Quaternion.identity);
       }
    */

    void SpawnProjectile()
    {  
        ObjectPool.instance.SpawnFromPool("projectile", player.position, Quaternion.identity);
    }
}
