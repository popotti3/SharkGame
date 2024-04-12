using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyPoolMangar : MonoBehaviour
{
    public static EnemyPoolMangar Instance;
    public GameObject enemyPrefab;
    
    public int poolSize = 10;

    private Queue<GameObject> enemyPool = new Queue<GameObject>();
    void Awake(){
        Instance = this;
        InitializePool();
    }

    private void InitializePool()
    {
      for(int i = 0; i <poolSize; i++){
        GameObject newEnemy = Instantiate(enemyPrefab);
        newEnemy.SetActive(false);
        enemyPool.Enqueue(newEnemy);
      }
    }

    // Start is called before the first frame update
    public GameObject GetEnemy(){
        if(enemyPool.Count > 0)
        {
            GameObject enemy = enemyPool.Dequeue();
             enemy.SetActive(true);
            return enemy;
        }
        return null;
        
    }

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
