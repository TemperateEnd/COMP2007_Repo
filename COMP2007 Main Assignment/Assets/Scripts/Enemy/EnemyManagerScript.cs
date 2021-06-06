using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    public GameObject stateManager;
    public GameObject enemyPrefab;
    public Vector3[] spawnPositions;
    public int enemiesToSpawn;
    public int maxSpawnLimitPerWave;

    public float timeBetweenWaves = 5f;
    public float countdown = 2f;

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

        maxSpawnLimitPerWave = enemiesToSpawn;
    }

    void Update() 
    {
        if(stateManager.GetComponent<StateManager>().enemyCountCurrentWave == 0 && stateManager.GetComponent<StateManager>().waveCount < 5) //If there are no enemies there: THIS SHOULD HOPEFULLY WORK WHEN THE PLAYER STARTS
        {
            GameObject.FindWithTag("Player").GetComponent<HealthManager>().IncreaseHP((GameObject.FindWithTag("Player").GetComponent<HealthManager>().maxHP - GameObject.FindWithTag("Player").GetComponent<HealthManager>().currHP)); //Replenish player health at the end of each wave
            
            if(countdown <= 0f)
            {
                NewWave();
                countdown = timeBetweenWaves;
                return;
            }
        }
    }

    //Make new enemies
    void NewWave()
    {
        stateManager.GetComponent<StateManager>().waveCount++;

        if(stateManager.GetComponent<StateManager>().enemyCountCurrentWave < maxSpawnLimitPerWave)
        {
            foreach (Vector3 spawnPoint in spawnPositions)
            {
                GameObject lastSpawnedEnemy = Instantiate<GameObject>(enemyPrefab, spawnPoint, Quaternion.identity);
                lastSpawnedEnemy.name = "Enemy";
            }
        }
    }
}