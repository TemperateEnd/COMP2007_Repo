﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private GameObject enemyKatana;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator enemyAnimController;
    public ParticleSystem targetParticles;

    [Header("Movement")]
    [SerializeField] private bool isMoving;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float dist;
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
        transform.LookAt(player.transform);

        if(Vector3.Distance(player.transform.position, transform.position) < dist) //Enemy stops and gets ready for combat if in range with player
        {
            this.gameObject.transform.Translate(0, 0, 0);
            enemyAnimController.SetBool("Running", false);
            enemyKatana.SetActive(true);
            enemyAnimController.SetTrigger("EquipWeapon");
            readyForCombat = true;
            canAttack = true;
        }

        else if(Vector3.Distance(player.transform.position, transform.position) > dist) //Enemy rushes at player until they are in range
        {
            enemyAnimController.SetBool("Running", true);
            this.gameObject.transform.Translate(0, 0, 1 * moveSpeed);
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
        player.GetComponent<PlayerUIScript>().enemiesKilled++;
    }
}