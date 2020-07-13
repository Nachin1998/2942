using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [Header("Asteroids")]
    public Asteroid asteroid;
    public Vector2 spawnValues;
    public float minSpeed;
    public float maxSpeed;

    public float spawnRate;
    float asteroidTimer;

    void Start()
    {
        Vector2 spawnPos = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y);
        asteroid.speed = Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        asteroidTimer += Time.deltaTime;
        
        if (asteroidTimer > spawnRate)
        {
            Vector2 spawnPos = new Vector2(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y);
            asteroid.speed = Random.Range(minSpeed, maxSpeed);
            Instantiate(asteroid, spawnPos, Quaternion.identity);
            asteroidTimer = 0;
        }
    }
}
