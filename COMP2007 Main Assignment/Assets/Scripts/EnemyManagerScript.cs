using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    public GameObject stateManager;
    public GameObject enemyPrefab;
    public Vector3[] spawnPositions;
    public int enemiesToSpawn;

    void Start() 
    {
        stateManager = GameObject.Find("StateMachine");

        if(stateManager.GetComponent<StateManager>().tutorialSelected)
        {
            enemiesToSpawn = 1;
        }

        else
        {
            enemiesToSpawn = 3;
        }

        SpawnEnemies();
    }

    public void SpawnEnemies()
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject lastSpawnedEnemy = Instantiate<GameObject>(enemyPrefab, spawnPositions[i], Quaternion.identity);
            Debug.Log("Enemy spawned at "+ spawnPositions[i]);
        }
    }
}
