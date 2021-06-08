using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagerScript : MonoBehaviour
{
    public GameObject stateManager;
    public GameObject enemyPrefab;
    public Vector3[] spawnPositions;
    [Header("Timers")]
    public float maxWaveTime;
    public float waveTimer;
    [SerializeField]private float maxSpawnTime;
    [SerializeField]private float spawnTimer;
    [SerializeField]private int enemiesToSpawn;
    [Header("Booleans")]
    [SerializeField]private bool stopSpawn;
    [SerializeField]private bool waveStarted;

    void Start() 
    {
        stateManager = GameObject.Find("StateMachine");

        stateManager.GetComponent<StateManager>().enemiesToKill = 25;
        enemiesToSpawn = 5; //Have it set up so that enemies are spawned in groups of 3 (I aim to have it so that the player has to kill 15 enemies)

        spawnTimer = maxSpawnTime;
        waveTimer = maxWaveTime;
    }

    void Update() 
    {
        if(stateManager.GetComponent<StateManager>().enemyCountCurrentWave == 0 && stateManager.GetComponent<StateManager>().waveCount < 5) //If there are no enemies there: THIS SHOULD HOPEFULLY WORK WHEN THE PLAYER STARTS
        {
            GameObject.FindWithTag("Player").GetComponent<HealthManager>().IncreaseHP((GameObject.FindWithTag("Player").GetComponent<HealthManager>().maxHP - GameObject.FindWithTag("Player").GetComponent<HealthManager>().currHP)); //Replenish player health at the end of each wave
            stopSpawn = false;
        }    

        else if (stateManager.GetComponent<StateManager>().enemyCountCurrentWave == enemiesToSpawn)
        {
            stopSpawn = true;
            waveStarted = false;
        }

        if(!stopSpawn && !waveStarted)
        {
            waveTimer -= Time.deltaTime;

            if(waveTimer < 0)
            {
                SpawnMethod();
                waveTimer = 0;   
            }
        }

        if(!stopSpawn && waveStarted)
        {
            waveTimer = maxWaveTime;
            for(int i = 0; i < enemiesToSpawn; i++)
            {
                spawnTimer -= Time.deltaTime;

                if(spawnTimer < 0)
                {
                    Instantiate<GameObject>(enemyPrefab, spawnPositions[i], Quaternion.identity);
                    spawnTimer = maxSpawnTime;
                }
            }
        }
    }
    void SpawnMethod() //Spawn new enemies
    {
        stateManager.GetComponent<StateManager>().waveCount++;
        waveStarted = true;  
    }
}