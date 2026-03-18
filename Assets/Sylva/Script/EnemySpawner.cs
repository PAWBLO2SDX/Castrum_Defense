using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;


//please help I can't stop using semicolons after comments  /  AND I DID IT AGAIN AFTER THAT ONE
public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner main;

    [Header("References")]
    [SerializeField] private GameObject levelManager;
    [SerializeField] private Waves[] waveScripts;
    [Header("Attributes")]
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [Header("Events")]
    public static UnityEvent onEnemyDestroy = new UnityEvent();
    
    private int currentWave = 0; //set to 0 by default because it'll be referenced for the index of wavePrefabs
    private float timeSinceLastSpawn; //Variable used to space out the spawn using the enemeiesPerSecond variable
    private bool isSpawning = false;
    private bool gamePaused = false; //adding this in case we want to make a pause menu in our game
    private int enemiesAlive;
    //private int enemiesToSpawn1;
    private int enemyIndex = 0;
    private GameObject newEnemy;
    public List<GameObject> spawnedEnemies;


    private void Awake()
    {
        main = this;
        onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    private void Update()
    {
        if (!isSpawning) return;
        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && !(waveScripts[currentWave].enemiesToSpawn.Length == enemiesAlive))
        {
            SpawnEnemy();
            enemiesAlive++;
            enemyIndex++;
            timeSinceLastSpawn = 0f;
        }

        if (enemiesAlive == 0 && waveScripts[currentWave].enemiesToSpawn.Length == enemyIndex + 1)
        {
            EndWave();
        }

        if (spawnedEnemies.Count > 0)
        {
            for (int i = 0; i < spawnedEnemies.Count; i++)
            {
                if (spawnedEnemies[i] == null)
                {
                    spawnedEnemies.Remove(spawnedEnemies[i]);
                }
            }
        }
    }

    public void SpawnEnemy()
    {
        GameObject prefabToSpawn = waveScripts[currentWave].enemiesToSpawn[enemyIndex];
        newEnemy = Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
        spawnedEnemies.Add(newEnemy);
    }

    public void StartWave()
    {
        if (!isSpawning && !gamePaused)
        {
            main.isSpawning = true;
            main.timeSinceLastSpawn = 0f;
            main.enemyIndex = 0;
        }
    }

    private void EndWave()
    {
        main.isSpawning = false;
    }

    private void EnemyDestroyed()
    {
        enemiesAlive--;
    }
}
