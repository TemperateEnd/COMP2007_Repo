using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] Animator playerAnimController;
    [Header("Speed Variables")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;

    [Header("Idle Timer Variables")]
    [SerializeField] private float idleTimer;
    [SerializeField] private float idleTimerMax;

    [Header("Movement booleans")]
    [SerializeField] private bool isRotating;
    [SerializeField] private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        idleTimer = idleTimerMax; //Sets it so that idleTimer starts at the max
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); //Gets value of Horizontal axis as player presses A and D
        float v = Input.GetAxisRaw("Vertical"); //Gets value of Vertical axis as player presses S and W

        if(Input.anyKey) //If player touches any key, idleTimer is reset
        {
            idleTimer = idleTimerMax;
            playerAnimController.SetBool("Idle", false);

            if(Input.GetButtonDown("Horizontal")) //If A or D are pressed, rotate left or right
            {
                isRotating = true;
            }

            if(Input.GetButtonDown("Vertical")) //If S or W are pressed, move forward or backwards
            {
                isMoving = true;
            }
        }

        if(Input.GetButtonUp("Vertical")) //If S or W are released, stop moving
        {
            isMoving = false;
        }

        if(Input.GetButtonUp("Horizontal")) //If A or D are released, stop rotating
        {
            isRotating = false;
        }

        if(isRotating) //Rotate if this is true
        {
            transform.Rotate(0, (h * rotateSpeed), 0);
        }

        if(isMoving) //Move if this is true
        {
            transform.Translate(0, 0, (v * moveSpeed));
            playerAnimController.SetBool("Running", true);
        }

        if(!isMoving) //Don't move if this is false
        {
            playerAnimController.SetBool("Running", false);
        }

        else //Play idle animation if idleTimer reaches 0
        {
            idleTimer -= Time.deltaTime;

            if(idleTimer <= 0)
            {
                playerAnimController.SetBool("Idle", true);
            }
        }
    }
}
