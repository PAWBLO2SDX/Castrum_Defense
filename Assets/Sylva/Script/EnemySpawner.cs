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
    private bool isSpawning = false;
    private int enemiesAlive;
    //private int enemiesToSpawn1;
    private int enemyIndex = 0;
    private GameObject newEnemy;
    public List<GameObject> spawnedEnemies;

    public static int OnWaveChanged { get; internal set; }

    private void Awake()
    {
        main = this;
        //onEnemyDestroy.AddListener(EnemyDestroyed);
    }

    private void Update()
    {
        
    }

    public void SpawnEnemy()
    {
        GameObject prefabToSpawn = waveScripts[currentWave].enemiesToSpawn[enemyIndex];
        newEnemy = Instantiate(prefabToSpawn, LevelManager.main.startPoint.position, Quaternion.identity);
        spawnedEnemies.Add(newEnemy);
    }
}
