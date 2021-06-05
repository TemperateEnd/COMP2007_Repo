using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    public GameObject stateManager;
    public GameObject enemyPrefab;
    public Vector3[] spawnPositions;
    public int enemiesToSpawn;
    public int maxEnemiesToSpawn;

    void Start() 
    {
        stateManager = GameObject.Find("StateMachine");

        if(stateManager.GetComponent<StateManager>().tutorialSelected)
        {
            enemiesToSpawn = 1; //This is just so that players don't fell overwhelmed when starting tutorial
        }

        else
        {
            enemiesToSpawn = 3; //Have it set up so that enemies are spawned in groups of 3 (I aim to have it so that the player has to kill 15 enemies)
        }
    }

    void Update() 
    {
        if(stateManager.GetComponent<StateManager>().enemyCountCurrentWave == 0 && stateManager.GetComponent<StateManager>().waveCount < 5) //If there are no enemies there: THIS SHOULD HOPEFULLY WORK WHEN THE PLAYER STARTS
        {
            GameObject.FindWithTag("Player").GetComponent<HealthManager>().currHP = GameObject.FindWithTag("Player").GetComponent<HealthManager>().maxHP; //Replenish player health at the end of each wave
            stateManager.GetComponent<StateManager>().waveCount++;
            SpawnEnemies();
        }
    }

    //Make new enemies
    public void SpawnEnemies()
    {
        for(int i = 0; i < enemiesToSpawn; i++)
        {
            GameObject lastSpawnedEnemy = Instantiate<GameObject>(enemyPrefab, spawnPositions[i], Quaternion.identity);
            Debug.Log("Enemy spawned at "+ spawnPositions[i]);
            lastSpawnedEnemy.name = "Enemy " + i;
        }
    }
}
