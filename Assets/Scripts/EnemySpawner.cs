using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private Transform player;
    public GameObject[] enemyPrefabs;
    public GameObject bulletPrefab;

    private void Start()
    {
        InvokeRepeating("SpawnEnemy", 1f, Random.Range(1f, 4f));
        InvokeRepeating("SpawnProjectile", 2f, 5f);
       /* Invoke("Spawn", 1f); //testing*/
    }

    Vector2 SpawnPos()
    {
        float randomX = (Random.Range(0, 2) == 0) ? player.position.x + 13 : player.position.x - 13;
        float randomY = (Random.Range(0, 2) == 0) ? player.position.z + 10 : player.position.z - 10;

        Vector3 randomPos = new Vector2(randomX, randomY);
        return randomPos;
    }

    void SpawnEnemy()
    {
        int randomIndex = Random.Range(0, enemyPrefabs.Length);
     
        Instantiate(enemyPrefabs[randomIndex], SpawnPos(), Quaternion.identity);

        print("Enemy spawned");
    }
    void SpawnProjectile()
    {
        Instantiate(bulletPrefab, player.transform.position, Quaternion.identity);
    }
}
