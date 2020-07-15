using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Player player;

    [Header("Asteroids")]
    public Asteroid asteroid;
    public Vector2 asteroidSpawnValues;
    public float minSpeed;
    public float maxSpeed;
    public float asteroidSpawnRate;

    [Space]

    [Header("Enemy Spaceships")]
    public Enemy enemy;
    public List<GameObject> enemySpawnPoints = new List<GameObject>();
    public float enemySpawnRate;

    float asteroidTimer;
    float enemyTimer;

    void Start()
    {
        asteroid.speed = Random.Range(minSpeed, maxSpeed);
    }


    void Update()
    {
        if (!player || player.won)
        {
            return;
        }

        UpdateAsteroid();
        UpdateEnemy();
    }

    void UpdateAsteroid()
    {
        asteroidTimer += Time.deltaTime;

        if (asteroidTimer > asteroidSpawnRate)
        {
            Vector2 spawnPos = new Vector2(Random.Range(-asteroidSpawnValues.x, asteroidSpawnValues.x), asteroidSpawnValues.y);
            asteroid.speed = Random.Range(minSpeed, maxSpeed);
            Instantiate(asteroid, spawnPos, Quaternion.identity);
            asteroidTimer = 0;
        }
    }

    void UpdateEnemy()
    {
        enemyTimer += Time.deltaTime;

        if(enemyTimer > enemySpawnRate)
        {
            int randomSpawner = Random.Range(0, enemySpawnPoints.Count);
            Instantiate(enemy, enemySpawnPoints[randomSpawner].transform.position, Quaternion.identity);
            enemyTimer = 0;
        }
    }
}
