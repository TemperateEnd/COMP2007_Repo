﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    public GameObject stateManager;
    public GameObject enemyPrefab;
    public Vector3[] spawnPositions;
    public float maxWaveTime;
    public float waveTimer;
    public float maxSpawnTime;
    public float spawnTimer;
    public int enemiesToSpawn;
    public int maxSpawnLimitPerWave;
    public bool stopSpawn;

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

        spawnTimer = maxSpawnTime;
        waveTimer = maxWaveTime;
    }

    void Update() 
    {
        if(stateManager.GetComponent<StateManager>().enemyCountCurrentWave == 0 && stateManager.GetComponent<StateManager>().waveCount < (stateManager.GetComponent<StateManager>().enemiesToKill / maxSpawnLimitPerWave)) //If there are no enemies there: THIS SHOULD HOPEFULLY WORK WHEN THE PLAYER STARTS
        {
            GameObject.FindWithTag("Player").GetComponent<HealthManager>().IncreaseHP((GameObject.FindWithTag("Player").GetComponent<HealthManager>().maxHP - GameObject.FindWithTag("Player").GetComponent<HealthManager>().currHP)); //Replenish player health at the end of each wave
            stopSpawn = false;
        }    

        else if (stateManager.GetComponent<StateManager>().enemyCountCurrentWave == enemiesToSpawn)
        {
            stopSpawn = true;
        }

        if(!stopSpawn)
        {
            waveTimer -= Time.deltaTime;
            if(waveTimer < 0)
            {
                SpawnMethod();
            }
        }
    }
    void SpawnMethod() //Spawn new enemies
    {
        stateManager.GetComponent<StateManager>().waveCount++;
        Debug.Log("New wave starts");
        
        for(int i = 0; i < maxSpawnLimitPerWave; i++)
        {
            spawnTimer -= Time.deltaTime;

            if(spawnTimer < 0)
            {
                Debug.Log("New enemy spawns");
                Instantiate<GameObject>(enemyPrefab, spawnPositions[i], Quaternion.identity);
                spawnTimer = maxSpawnTime;
            }
        }
    }
}