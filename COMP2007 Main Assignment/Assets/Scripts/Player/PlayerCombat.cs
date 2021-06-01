using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject playerKatana;
    [SerializeField] private Animator playerAnimController;
    [SerializeField] private bool readyForCombat;
    [SerializeField] private bool weaponReady;

    // Start is called before the first frame update
    void Start()
    {
        readyForCombat = false;
        playerKatana.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Equip Weapon"))
        {
            weaponReady = !weaponReady;
            readyForCombat = !readyForCombat;
        }

        if(readyForCombat)
        {
            if(Input.GetButtonDown("Attack"))
            {
                playerAnimController.SetInteger("AttackCombo", playerAnimController.GetInteger("AttackCombo")+1);

                if(playerAnimController.GetInteger("AttackCombo") > 2)
                {
                    playerAnimController.SetInteger("AttackCombo", 0);
                }
            }
        }

        if(!weaponReady)
        {
            playerKatana.SetActive(true);
            playerAnimController.SetBool("ReadyForCombat", true);
        }

        else if(weaponReady)
        {
            playerAnimController.SetBool("ReadyForCombat", false);
            playerKatana.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision col) 
    {
        if(col.gameObject.tag == "EnemyWeapon")
        {
            this.gameObject.GetComponent<HealthManager>().currHP -= 25;
        }
    }
}
