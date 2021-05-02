using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartState : IBaseState
{
    private StateManager stateManager;
    private Scene scene;

    public StartState(StateManager stateManagerRef)
    {
        stateManager = stateManagerRef;
        scene = SceneManager.GetActiveScene();

        if(scene.name != "StartState")
        {
            SceneManager.LoadScene("StartState");
        }
    }

    public void StateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SwitchOver();
        }
    }

    public void SwitchOver()
    {
        StateManager.InstanceRef.SwitchState(new PlayState(StateManager.InstanceRef));
    }
}