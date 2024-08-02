using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    public GameObject[] enemyPrefabs;
    public GameObject bulletPrefab;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, 3f);
        InvokeRepeating("SpawnProjectile", 2f, 1f);
       /* Invoke("SpawnEnemy", 1f); //testing*/
    }
    
        Vector2 SpawnPos1()
        {
            float randomX = (Random.Range(0, 2) == 0) ? player.position.x + 13 : player.position.x - 13;
            float randomY = (Random.Range(-10, 10));

            Vector3 randomPos = new Vector2(randomX, randomY);
            return randomPos;
        }
    
    Vector2 SpawnPos2()
    {
        float randomX = (Random.Range(-13, 13));
        float randomY = (Random.Range(0, 2) == 0) ? player.position.y + 10 : player.position.y - 10;

        Vector3 randomPos = new Vector2(randomX, randomY);
        return randomPos;
    }


    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
     
        Instantiate(enemyPrefabs[randomIndex], SpawnPos1(), Quaternion.identity);

        Instantiate(enemyPrefabs[randomIndex], SpawnPos2(), Quaternion.identity);

        print("Enemy spawned");
    }
    void SpawnProjectile()
    {
        Instantiate(bulletPrefab, player.transform.position, Quaternion.identity);
    }
}
