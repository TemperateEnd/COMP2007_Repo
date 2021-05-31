using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] Animator playerAnimController;
    [Header("Speed Variables")]
    public float moveSpeed;
    public float rotateSpeed;

    [Header("Idle Timer Variables")]
    public float idleTimer;
    public float idleTimerMax;

    [Header("Movement booleans")]
    public bool isRotating;
    public bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        idleTimer = idleTimerMax;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if(Input.anyKey)
        {
            idleTimer = idleTimerMax;
            playerAnimController.SetBool("Idle", false);

            if(Input.GetButton("Horizontal"))
            {
                Debug.Log("Player has pressed rotate button");
                isRotating = true;
            }

            else if(Input.GetButtonUp("Horizontal"))
            {
                Debug.Log("Player has released rotate button");
                isRotating = false;
            }

            if(Input.GetButton("Vertical")) 
            {
                Debug.Log("Player has pressed move button");
                isMoving = true;
            }

            else if(Input.GetButtonUp("Vertical"))
            {
                Debug.Log("Player has released move button");
                isMoving = false;
            }
        }

        if(isRotating)
        {
            transform.Rotate(0, (h * rotateSpeed), 0);
        }

        if(isMoving)
        {
            Debug.Log("Should be moving");
            transform.Translate(0, 0, (v * moveSpeed));
            playerAnimController.SetBool("Running", true);
        }

        if(!isMoving)
        {
            playerAnimController.SetBool("Running", false);
        }

        else
        {
            idleTimer -= Time.deltaTime;

            if(idleTimer <= 0)
            {
                Debug.Log("Player is currently idle");
                playerAnimController.SetBool("Idle", true);
            }
        }
    }
}
