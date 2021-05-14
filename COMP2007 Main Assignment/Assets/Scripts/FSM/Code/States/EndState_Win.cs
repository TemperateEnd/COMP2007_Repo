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

        stateManager.mainCam = GameObject.Find("Main Camera");

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

    void Start()
    {
        stateManager.mainCam = GameObject.Find("Main Camera");
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
