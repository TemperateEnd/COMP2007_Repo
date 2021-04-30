﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndState_Win : IBaseState
{
    private StateManager stateManager;
    private Scene scene;

    public EndState_Win(StateManager stateManagerRef)
    {
        stateManager = stateManagerRef;
        scene = SceneManager.GetActiveScene();

        if(scene.name != "EndState_Win")
        {
            SceneManager.LoadScene("EndState_Win");
        }
        Debug.Log("Constructing Win State");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SwitchOver();
        }
    }

    void SwitchOver()
    {
        Debug.Log($"was in state {SceneManager.GetActiveScene().name}");
        StateManager.InstanceRef.SwitchState(new PlayState(StateManager.InstanceRef));
    }
}
