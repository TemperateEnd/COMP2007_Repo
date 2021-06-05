using System.Collections;
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
        
        for(int i = 0; i < stateManager.UI.Length; i++)
        {
            if(stateManager.UI[i].gameObject.name == "exitStateWinUI")
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
    }

    void SwitchOver()
    {
        StateManager.InstanceRef.SwitchState(new StartState(StateManager.InstanceRef));
    }
}
