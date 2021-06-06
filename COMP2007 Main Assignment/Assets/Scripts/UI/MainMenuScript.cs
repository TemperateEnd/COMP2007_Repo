using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//All scripts related to the main game UI (with exception of the actual Player UI) will be using this template due to the fact that it works with the FSM
public class MainMenuScript : MonoBehaviour
{
    public void ButtonMethod(string buttonFunction)
    {
        switch(buttonFunction)
        {
            case "Start":
                StateManager.InstanceRef.SwitchState(new PlayState(StateManager.InstanceRef)); //Start game
                StateManager.InstanceRef.tutorialSelected = false;
                this.gameObject.SetActive(false);
                break;
            case "Tutorial":
                StateManager.InstanceRef.SwitchState(new PlayState(StateManager.InstanceRef)); //Start game - tutorial enabled
                StateManager.InstanceRef.tutorialSelected = true;
                this.gameObject.SetActive(false);
                break;
            case "Exit":
                Application.Quit(); //Exit game
                break;
        }
    }
}
