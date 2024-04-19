using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawner : MonoBehaviour
{
    // Start is called before the first frame update

    public float spawnInterval = 2f;

    private float nextSpawnTime;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time < nextSpawnTime)
        {
            return;
        }

        nextSpawnTime = Time.time + spawnInterval;
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        GameObject enemy = EnemyPoolMangar.Instance.GetEnemy();
        if(enemy != null){
        enemy.transform.position = transform.position;
        }

        nextSpawnTime = Time.time + spawnInterval;
    }
}
