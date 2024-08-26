using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public Spawner spawner;
    private float timer;
    [SerializeField]
    private float waveInterval;
    private float spawnInterval;
    private int goblinChance;
    private int banditChance;
    private int ogreChance;
    private int randomNumber;

    private void Start()
    {
       // waveInterval = 10f;
        spawnInterval = 2.5f;
        goblinChance = 100;
        goblinChance = 100 - (banditChance + ogreChance);
        StartCoroutine(EnemySpawner());
    }


    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= waveInterval)
        {
            timer = 0;
            ChangeEnemy();
        }
    }

    void EnemySpawn()
    {
        randomNumber = Random.Range(1, 100);

        if(randomNumber <= goblinChance) 
        {
            spawner.SpawnGoblin();
        }
        if(randomNumber <= banditChance)
        {
            spawner.SpawnBandit();
        }
        if(randomNumber <= ogreChance)
        {
            spawner.SpawnOgre();
        }
    }

    void ChangeEnemy()
    {
        if(goblinChance >= 10)
        {
            goblinChance -= 5;
        }
        if (goblinChance <= 50 && banditChance <= 50)
        {
            banditChance += 10;
        }
        if(banditChance >= 40 && ogreChance <= 30)
        {
            ogreChance += 5;
        }

    }
    
    IEnumerator EnemySpawner()
    {
        while(true)
        {
            EnemySpawn();
            print("random number" + randomNumber);
            yield return new WaitForSeconds(spawnInterval);
        }       
    }





















}
   /* public Spawner spawner;
    public List<Enemies> enemies = new List<Enemies>();
    public List<GameObject> enemiesToSpawn = new List<GameObject>();
    private float spawnTimer;
    private int currentWave;
    private int waveValue;
    private int waveDuration;
    private float spawnInterval;
    private float waveTimer;


    private void Start()
    {
        currentWave = 1;
        GenerateWave();
    }

    private void FixedUpdate()
    {
        if (spawnTimer <= 0)
        {
            Instantiate(enemiesToSpawn[0], spawner.spawnPos(), Quaternion.identity);
            enemiesToSpawn.RemoveAt(0);
            spawnTimer = spawnInterval;
        }
        else 
        {
            spawnTimer -= Time.fixedDeltaTime;
            waveTimer -= Time.fixedDeltaTime;
        }

    }
 
    void GenerateWave()
    {
        waveValue = currentWave * 10;
        
        GenerateEnemies();

        spawnInterval = waveDuration / enemiesToSpawn.Count;

        waveTimer = waveDuration;
    }

    public void GenerateEnemies()
    {
        List<GameObject> generatedEnemies = new List<GameObject>();

        while(waveValue > 0)
        {
            int randomEnemyId = Random.Range(0, enemies.Count);
            int randomEnemyCost = enemies[randomEnemyId].cost;

            if(waveValue - randomEnemyCost >= 0)
            {
                generatedEnemies.Add(enemies[randomEnemyId].prefab);
                waveValue -= randomEnemyCost;
            }
            else if(waveValue <= 0)
            {
                break;
            }
        }
        enemiesToSpawn.Clear();
        enemiesToSpawn = generatedEnemies;
    }


  /*  void ChangeEnemy()
    {
        currentWave++;

        switch (currentWave)
        {
            case 1:
                spawner.SpawnBandit();
                break;

            case 2:
                spawner.SpawnOgre();
                break;
            
            default:
                spawner.SpawnGoblin();
                break;
        }   
    }
}

[System.Serializable]
public class Enemies
{
    public GameObject prefab;
    public int cost;
}
*/