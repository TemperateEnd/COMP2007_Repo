using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWinScript : MonoBehaviour
{
    public void ButtonMethod(string buttonFunction)
    {
        switch(buttonFunction)
        {
            case "Restart":
                StateManager.InstanceRef.SwitchState(new PlayState(StateManager.InstanceRef)); //Start game again
                this.gameObject.SetActive(false);
                break;
            case "Exit":
                StateManager.InstanceRef.SwitchState(new StartState(StateManager.InstanceRef)); //Return to main menu
                this.gameObject.SetActive(false);
                break;
        }
    }
}
