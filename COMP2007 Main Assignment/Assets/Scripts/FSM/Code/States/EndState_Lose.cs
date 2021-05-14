using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndState_Lose : IBaseState
{
    private StateManager stateManager;
    private Scene scene;

    public EndState_Lose(StateManager stateManagerRef)
    {
        stateManager = stateManagerRef;
        scene = SceneManager.GetActiveScene();

        if(scene.name != "EndState_Lose")
        {
            SceneManager.LoadScene("EndState_Lose");
        }

        stateManager.mainCam = GameObject.Find("Main Camera");
        
        for(int i = 0; i < stateManager.UI.Length; i++)
        {
            if(stateManager.UI[i].gameObject.name == "exitStateLossUI")
            {
                stateManager.UI[i].SetActive(true);
            }

            else
            {
                stateManager.UI[i].SetActive(false);
            }
        }
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