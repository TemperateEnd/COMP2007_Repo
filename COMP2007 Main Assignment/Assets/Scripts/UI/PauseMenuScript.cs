using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
    void Start() 
    {
        Time.timeScale = 0;
    }
    public void ButtonMethod(string buttonFunction)
    {
        switch(buttonFunction)
        {
            case "Resume":
                this.gameObject.SetActive(false);
                Time.timeScale = 1;
                break;
            case "Quit":
                StateManager.InstanceRef.SwitchState(new StartState(StateManager.InstanceRef)); //Return to main menu
                break;
        }
    }
}
