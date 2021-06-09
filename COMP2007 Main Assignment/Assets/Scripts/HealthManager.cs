using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Headnote: My work on the Health side of things (the HealthManager and PlayerUIScript scripts) will be slightly derivative of what I did in Set Exercise 2
public class HealthManager : MonoBehaviour 
{
    public float maxHP;
    public float currHP;
    public enum healthState { DefaultState, LosingHP, GainingHP } //This is for the Player UI when having the UI decide what audio is played
    public healthState hpState;
    [SerializeField] private StateManager currentStateManager;

    // Start is called before the first frame update
    void Start() 
    {
        currHP = maxHP;
        hpState = healthState.DefaultState;

        currentStateManager = GameObject.Find("StateMachine").GetComponent<StateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currHP > maxHP)
        {
            currHP = maxHP; //Stops currHP from going over maxHP
        }

        else if (currHP < 0)
        {
            currHP = 0; //Stops currHP from going under 0
        }

        if(currHP <= 0)
        {
            DeathEvent(); //If all health is lost, call method that does something depending on who lost HP
        }
    }

    //Subtract HP
    public void DecreaseHP(float hpLoss)
    {
        hpState = healthState.LosingHP;
        currHP -= (hpLoss + (currentStateManager.waveCount * 5)); /** Increase damage loss with each wave. By default, 
                                                                    this should mean that enemy and player both loss 30 HP on wave 1,
                                                                  with an additional 5 HP added as the game goes on (I am projecting a 
                                                                50 HP loss by wave 5**/
    }

    //Add HP
    public void IncreaseHP(float hpGain)
    {
        hpState = healthState.GainingHP;
        currHP += hpGain;
    }

    void DeathEvent()
    {
        if(this.gameObject.tag == "Player") //This only happens if this is the player character
        {
            currentStateManager.playerDead = true;
        }

        else if(this.gameObject.tag == "Enemy") //Happens if this is the enemy
        {
            Destroy(this.gameObject);
            GameObject.FindWithTag("Player").GetComponent<PlayerCombat>().targetNumber = 0; //Set target number to first target on list
            currentStateManager.enemiesToKill--; //Subtracts total remaining number of enemies in state machine
            currentStateManager.GetComponentInChildren<PlayerUIScript>().enemiesKilled++; //Updates number of enemies killed by player
        }
    }
}
