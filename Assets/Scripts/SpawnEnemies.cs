using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private Transform[] spawnPoints;

    [Header("Enemy Properties")]
    [SerializeField] private Transform enemiesContainer;
    [SerializeField] private float enemySpeed = 5f;

    [Header("Enemy Random Values")]
    [SerializeField] private int enemyIndex;
    [SerializeField] private int spawnPointIndex;
    [SerializeField] private int enemiesAmount;
    [SerializeField] private float spawnTime;
    void Start()
    {
        spawnTime = 1;
    }

    void Update()
    {
        Timer();
    }

    void Timer()
    {
        spawnTime -= Time.deltaTime * 1f;

        if(spawnTime <= 0)
        {
            SetSpawnEnemiesValues();
        }
    }
    void SetSpawnEnemiesValues()
    {
        enemiesAmount = Random.Range(2, 6);
        SetRandomEnemyValues();
        SpawnEnemy();
    }
    void SetRandomEnemyValues()
    {
        enemyIndex = Random.Range(0, 5);
        spawnPointIndex = Random.Range(0, 5);
        spawnTime = Random.Range(1, 3);
    }
   
    void SpawnEnemy()
    {
        for(int i = 0; i <= enemiesAmount; i++)
        {
            var enemy = Instantiate(enemies[enemyIndex], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            enemy.GetComponent<Rigidbody2D>().velocity = -spawnPoints[spawnPointIndex].right * enemySpeed;
            enemy.transform.parent = enemiesContainer;
            SetRandomEnemyValues();
        }
    }
}
