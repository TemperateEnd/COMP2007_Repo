using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject enemyKatana;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator enemyAnimController;
    public TMP_Text targetText;

    [Header("Movement")]
    public bool isMoving = true;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float attackDistance;
    [SerializeField] private float currDistance;
    public Vector3 currPosition;
    public Vector3 targetPosition;

    [Header("Combat")]
    public bool canAttack;
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
        targetText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        currPosition = transform.position;
        targetPosition = player.transform.position;
        currDistance = Vector3.Distance(currPosition, targetPosition);

        if (currDistance > attackDistance)
        {
            isMoving = true;
        }

        if(currDistance <= attackDistance)
        {
            Debug.Log("Within attack range");
            isMoving = false;
        }

        if(!isMoving) //Enemy stops and gets ready for combat if in range with player
        {
            transform.Translate(Vector3.zero);
            enemyAnimController.SetBool("Running", false);
            enemyKatana.SetActive(true);
            enemyAnimController.SetTrigger("EquipWeapon");
            readyForCombat = true;
            canAttack = true;
        }

        if(isMoving) //Enemy rushes at player until they are in range
        {
            transform.Translate(0, 0, 1 * moveSpeed);
            readyForCombat = false;
            canAttack = false;
            enemyAnimController.SetBool("Running", true);
        }

        if((readyForCombat == true) && (canAttack == true)) //Enemy waits before attacking
        {
            cooldownTime -= Time.deltaTime;

            if(cooldownTime <= 0)
            {
                StartCoroutine("Attack");
                cooldownTime = maxCooldownTime;
            }
        }
    }

    IEnumerator Attack() //Attacks player, playing varying animations depending on value of AttackNumber
    {
        enemyAnimController.SetTrigger("Attacking");

        enemyAnimController.SetInteger("AttackNumber", enemyAnimController.GetInteger("AttackNumber")+1);

        if(enemyAnimController.GetInteger("AttackNumber") > 2)
        {
            enemyAnimController.SetInteger("AttackNumber", 1);
        }

        yield return new WaitForSeconds(attackTimer);
        player.GetComponent<HealthManager>().DecreaseHP(25);
    }
}