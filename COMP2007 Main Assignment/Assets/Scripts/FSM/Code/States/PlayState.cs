using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayState : IBaseState
{
    private StateManager stateManager;
    private Scene scene;

    public PlayState(StateManager stateManagerRef)
    {
        stateManager = stateManagerRef;
        scene = SceneManager.GetActiveScene();

        if(scene.name != "PlayState")
        {
            SceneManager.LoadScene("PlayState");
        }

        for(int i = 0; i < stateManager.UI.Length; i++)
        {
            if(stateManager.UI[i].gameObject.name == "PlayerUI")
            {
                stateManager.UI[i].SetActive(true);
            }

            else
            {
                stateManager.UI[i].SetActive(false);
            }
        }

        if(stateManager.GetComponent<StateManager>().tutorialSelected)
        {
            stateManager.enemyCount = 1;
        }

        else
        {
            stateManager.enemyCount = 3;
        }


    }

    public void StateUpdate()
    {
        if(stateManager.enemyCount == 0)
        {
            SwitchOverWon();
        }

        // else if(Input.GetKeyDown(KeyCode.L))
        // {
        //     Debug.Log($"Switching over from {SceneManager.GetActiveScene().name}");
        //     SwitchOverLost();
        // }

        // else if (Input.GetKeyDown(KeyCode.Backspace))
        // {
        //     StateManager.InstanceRef.SwitchState(new StartState(StateManager.InstanceRef));
        // }
    }

    void SwitchOverWon()
    {
        StateManager.InstanceRef.SwitchState(new EndState_Win(StateManager.InstanceRef));
    }

    void SwitchOverLost()
    {
        StateManager.InstanceRef.SwitchState(new EndState_Lose(StateManager.InstanceRef));
    }
}