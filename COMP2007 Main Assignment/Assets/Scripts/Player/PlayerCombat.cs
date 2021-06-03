using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject playerKatana;
    [SerializeField]private Animator playerAnimController;
    [SerializeField]private float maxAttackTime;

    [SerializeField] private GameObject[] targets;
    private int targetNumber;
    [SerializeField] private GameObject currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        playerKatana.SetActive(false);
        targets = GameObject.FindGameObjectsWithTag("Enemy");
        currentTarget = targets[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Equip Weapon"))
        {
            playerKatana.SetActive(!playerKatana.activeSelf);

            if(playerKatana.activeSelf == true)
            {
                playerAnimController.SetTrigger("EquipWeapon");
            }

            else if(playerKatana.activeSelf == false)
            {
                playerAnimController.SetTrigger("UnequipWeapon");
            }
        }

        if(Input.GetButtonDown("Attack") && playerKatana.activeSelf == true)
        {
            playerAnimController.SetTrigger("isAttacking");

            playerAnimController.SetInteger("attackNumber", playerAnimController.GetInteger("attackNumber")+1);

            if(playerAnimController.GetInteger("attackNumber") > 2)
            {
                playerAnimController.SetInteger("attackNumber", 1);
            }

            currentTarget.GetComponent<HealthManager>().currHP -= 25;
        }

        if(Input.GetButtonDown("Change Target"))
        {
            if(targetNumber > targets.Length)
            {
                targetNumber = 0;
            }

            else
            {
                targetNumber++;
            }
            
            currentTarget = targets[targetNumber];
        }
    }
}