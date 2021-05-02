using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    public void ButtonMethod(string buttonFunction)
    {
        switch(buttonFunction)
        {
            case "Start":
                StateManager.InstanceRef.SwitchState(new PlayState(StateManager.InstanceRef));
                StateManager.InstanceRef.tutorialSelected = false;
                break;
            case "Tutorial":
                StateManager.InstanceRef.SwitchState(new PlayState(StateManager.InstanceRef));
                StateManager.InstanceRef.tutorialSelected = true;
                break;
            case "Exit":
                Application.Quit();
                break;
        }
    }
}
