using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject enemyKatana;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator enemyAnimController;
    [Header("Movement")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float combatRange;

    [Header("Combat")]
    [SerializeField] private float attackTimer;
    [SerializeField] private bool readyForCombat;

    // Start is called before the first frame update
    void Start()
    {
        enemyKatana.SetActive(false);
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if((this.gameObject.transform.position.z - player.transform.position.z) < combatRange)
        {
            enemyKatana.SetActive(true);
            enemyAnimController.SetBool("Running", false);
            enemyAnimController.SetTrigger("EquipWeapon");
            readyForCombat = true;
        }

        else if((this.gameObject.transform.position.z - player.transform.position.z) > combatRange)
        {
            this.gameObject.transform.LookAt(player.transform);
            this.gameObject.transform.Translate(0, 0, moveSpeed * Time.deltaTime);
            enemyAnimController.SetBool("Running", true);
        }

        if(readyForCombat = true)
        {
            StartCoroutine("Attack");
        }
    }

    private void OnCollisionEnter(Collision col) 
    {
        if(col.gameObject.tag == "PlayerWeapon")
        {
            Debug.Log("Player weapon collision detected");
            this.gameObject.GetComponent<HealthManager>().currHP -= 25;
        }
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(attackTimer);
        enemyAnimController.SetTrigger("isAttacking");

        enemyAnimController.SetInteger("attackNumber", enemyAnimController.GetInteger("attackNumber")+1);

        if(enemyAnimController.GetInteger("attackNumber") > 2)
        {
            enemyAnimController.SetInteger("attackNumber", 1);
        }
    }
}