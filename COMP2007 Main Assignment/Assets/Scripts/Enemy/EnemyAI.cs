using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject enemyKatana;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator enemyAnimController;
    [Header("Movement")]
    [SerializeField] private bool isMoving;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float combatRange;
    public bool canAttack;

    [Header("Combat")]
    [SerializeField] private float attackTimer;
    [SerializeField] private float maxCooldownTime;
    [SerializeField] private float cooldownTime;
    [SerializeField] private bool readyForCombat;

    // Start is called before the first frame update
    void Start()
    {
        cooldownTime = maxCooldownTime;
        enemyKatana.SetActive(false);
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if((this.gameObject.transform.position.z - player.transform.position.z) < combatRange)
        {
            isMoving = false;
            enemyKatana.SetActive(true);
            enemyAnimController.SetTrigger("EquipWeapon");
            readyForCombat = true;
            canAttack = true;
        }

        else if((this.gameObject.transform.position.z - player.transform.position.z) > combatRange)
        {
            this.gameObject.transform.LookAt(player.transform);
            isMoving = true;
        }

        if((readyForCombat == true) && (canAttack == true))
        {
            cooldownTime -= Time.deltaTime;

            if(cooldownTime <= 0)
            {
                StartCoroutine("Attack");
                cooldownTime = maxCooldownTime;
            }
        }

        if(isMoving)
        {
            this.gameObject.transform.Translate(0, 0, 1 * moveSpeed);
            enemyAnimController.SetBool("Running", true);
        }

        if(!isMoving)
        {
            enemyAnimController.SetBool("Running", false);
        }
    }

    IEnumerator Attack()
    {
        enemyAnimController.SetTrigger("isAttacking");

        enemyAnimController.SetInteger("attackNumber", enemyAnimController.GetInteger("attackNumber")+1);

        if(enemyAnimController.GetInteger("attackNumber") > 2)
        {
            enemyAnimController.SetInteger("attackNumber", 1);
        }

        yield return new WaitForSeconds(attackTimer);
        player.GetComponent<HealthManager>().currHP -= 25;
    }
}