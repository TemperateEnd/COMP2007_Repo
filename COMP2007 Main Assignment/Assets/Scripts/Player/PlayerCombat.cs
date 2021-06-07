using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject playerKatana;
    [SerializeField]private Animator playerAnimController;
    [SerializeField]private float maxAttackTime;
    [SerializeField]private float attackTimer;
    [SerializeField]private bool canAttack;
    public GameObject[] targets;
    public int targetNumber; //This is so that HealthManager can access it and set it to 0 when an enemy dies
    [SerializeField] private GameObject currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        playerKatana.SetActive(false); /**By default, weapon is not enabled. After all, a wise man said something about using something for defense and not attack 
                                        (for those who saw Episode V: Best plot twist ever)**/
        canAttack = false; //Attack, you cannot. For enabled, the weapon is not.
        attackTimer = maxAttackTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy") != null) //If enemies exist, populate targets array and target first enemy on list by default
        {
            targets = GameObject.FindGameObjectsWithTag("Enemy");
            currentTarget = targets[0];
        }

        currentTarget.GetComponent<EnemyAI>().targetText.enabled = true;
        targets = GameObject.FindGameObjectsWithTag("Enemy"); //Fill array of targets with all enemies currently in scene
        
        if(Input.GetButtonDown("Equip Weapon")) //If F key is pressed, play animation and enable katana Gameobject
        {
            playerKatana.SetActive(!playerKatana.activeSelf);
            canAttack = !canAttack;

            if(playerKatana.activeSelf == true)
            {
                playerAnimController.SetTrigger("EquipWeapon");
            }

            else if(playerKatana.activeSelf == false)
            {
                playerAnimController.SetTrigger("UnequipWeapon");
            }
        }

        if(Input.GetButtonDown("Attack") && playerKatana.activeSelf == true) //If LMB is pressed and katana Gameobject is active
        {
            playerAnimController.SetTrigger("isAttacking");

            playerAnimController.SetInteger("attackNumber", playerAnimController.GetInteger("attackNumber")+1); // Play different animations depending on attackNumber 

            if(playerAnimController.GetInteger("attackNumber") > 2)
            {
                playerAnimController.SetInteger("attackNumber", 1); //Reset attackNumber to 1 if it goes over 2
            }

            if(currentTarget.GetComponent<EnemyAI>().canAttack == true) //If enemy is currently targeted, knock their HP down a bit and bring them closer to destruction!
            {
                currentTarget.GetComponent<HealthManager>().DecreaseHP(25);
            }

            canAttack = false;

            attackTimer -= Time.deltaTime;

            if(attackTimer < 0)
            {
                canAttack = true;
                attackTimer = maxAttackTime;
            }
        }

        if(Input.GetButtonDown("Change Target")) //If Tab key is pressed, change target
        {
            if(targetNumber > targets.Length)
            {
                targetNumber = 0;
            }

            else
            {
                targetNumber++;
                targets[targetNumber-1].GetComponent<EnemyAI>().targetText.enabled = false;
            }
        }

        currentTarget = targets[targetNumber]; //has it so that target changes if target number changes
        currentTarget.GetComponent<EnemyAI>().targetText.enabled = true;
    }
}