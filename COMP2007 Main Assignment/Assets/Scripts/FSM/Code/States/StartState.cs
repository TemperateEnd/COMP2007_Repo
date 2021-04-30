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
        Debug.Log("Constructing Start State");
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
            Debug.Log($"was in state {SceneManager.GetActiveScene().name}");
            SwitchOver();
        }
        
    }

    void SwitchOver()
    {
        Debug.Log($"was in state {SceneManager.GetActiveScene().name}");
        StateManager.InstanceRef.SwitchState(new PlayState(StateManager.InstanceRef));
    }
}