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
        stateManager.enemiesToKill = 21;

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
    }

    public void StateUpdate()
    {
        if(stateManager.enemiesToKill == 0)
        {
            SwitchOverWon(); //If player kills all enemies, they win
        }

        else if(stateManager.playerDead == true)
        {
            SwitchOverLost(); //If player is dead, they lose
        }
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