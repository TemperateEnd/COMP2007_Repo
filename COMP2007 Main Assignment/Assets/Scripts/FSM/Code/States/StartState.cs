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

        stateManager.UI[0].gameObject.SetActive(true);

        for(int i = 0; i < stateManager.UI.Length; i++)
        {
            if(stateManager.UI[i].gameObject.name == "MainMenuUI")
            {
                stateManager.UI[i].SetActive(true);
            }

            else
            {
                stateManager.UI[i].SetActive(false);
            }
        }

        stateManager.mainCam = GameObject.Find("Main Camera");
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