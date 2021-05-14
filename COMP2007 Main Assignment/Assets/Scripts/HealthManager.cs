using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour 
{
    public float maxHP;
    public float currHP;

    [SerializeField] private StateManager currentStateManager;

    // Start is called before the first frame update
    void Start() 
    {
        currHP = maxHP;

        if(this.gameObject.name == "PlayerCharacter")
        {
            currentStateManager = GameObject.Find("StateMachine").GetComponent<StateManager>();
        }

        else
        {
            currentStateManager = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(currHP > maxHP)
        {
            currHP = maxHP;
        }

        else if (currHP < 0)
        {
            currHP = 0;
        }

        if(currHP <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        if(currentStateManager != null) //This only happens if this is the player character
        {
            //currentStateManager.instanceRef.SwitchState(new EndState_Lose(currentStateManager.instanceRef));
        }

        else
        {
            Destroy(this.gameObject);
        }
    }
}
