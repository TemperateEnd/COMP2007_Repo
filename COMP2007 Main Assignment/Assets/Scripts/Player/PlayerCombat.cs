using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public GameObject playerKatana;
    [SerializeField]private Animator playerAnimController;
    [SerializeField]private float maxAttackTime;

    // Start is called before the first frame update
    void Start()
    {
        playerKatana.SetActive(false);
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
        }
    }

    private void OnCollisionEnter(Collision col) 
    {
        if(col.gameObject.tag == "EnemyWeapon")
        {
            Debug.Log("Enemy weapon collision detected");
            this.gameObject.GetComponent<HealthManager>().currHP -= 25;
        }
    }
}