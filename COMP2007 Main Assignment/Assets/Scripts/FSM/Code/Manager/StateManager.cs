using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// First attempt at implementing my own Finite State Machine (in any and all works linked to this
/// assignment, we will be using the FSM abbrieviation when refering to this).
///</summary>

public class StateManager : MonoBehaviour
{
    [SerializeField]private IBaseState IActiveState;
    public static StateManager InstanceRef = null;
    private static StateManager instanceRef;
    public bool playerDead = false; //Check if player still lives
    public bool playerVictory = false; //Check if player still lives
    public GameObject[] UI; //UI for various game states
    public Canvas uiCanvas;
    public GameObject mainCam;
    [Header("For enemy spawning in play state")]
    public int enemyCountCurrentWave; //Enemies remaining in current wave
    public int enemiesToKill; //Total amount of enemies remaining for player to kill
    public int waveCount; //For use when increasing stats for both enemy and player

    private void Awake() 
    {
        QualitySettings.vSyncCount = 0;  // VSync must be disabled
        Application.targetFrameRate = 60;

        mainCam = GameObject.FindWithTag("MainCamera"); //Finds camera in Scene and assigns it to mainCam
        uiCanvas.worldCamera = mainCam.GetComponent<Camera>();

        if(instanceRef != null) //If something already exists, destroy the GameObject
        {
            DestroyImmediate(gameObject);
        }

        else
        {
            instanceRef = this;
            DontDestroyOnLoad(instanceRef);
            InstanceRef = instanceRef;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        IActiveState = new StartState(this);
    }

    // Update is called once per frame
    private void Update()
    {
        mainCam = GameObject.FindWithTag("MainCamera"); //Finds camera in Scene and assigns it to mainCam

        if(IActiveState != null)
        {
            IActiveState.StateUpdate();
        }

        enemyCountCurrentWave = GameObject.FindWithTag("Player").GetComponent<PlayerCombat>().targets.Length;

        if(Input.GetButtonDown("Pause"))
        {
            UI[2].SetActive(true);
        }

        if(enemiesToKill == 0)
        {
            playerVictory = true;
        }
    }

    public void SwitchState(IBaseState nextState)
    {
        IActiveState = nextState;
    }
}