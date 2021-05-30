using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    [Header("Speed Variables")]
    public float moveSpeed;
    public float rotateSpeed;

    [Header("Idle Timer Variables")]
    public float idleTimer;
    public float idleTimerMax;

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

            if(Input.GetButtonDown("Horizontal"))
            {
                isRotating = true;
            }

            if(Input.GetButtonUp("Horizontal"))
            {
                isRotating = false;
            }

            if(Input.GetButtonDown("Vertical")) 
            {
                isMoving = true;
            }

            if(Input.GetButtonUp("Vertical"))
            {
                isMoving = false;
            }
        }

        else
        {
            idleTimer -= Time.deltaTime;

            if(idleTimer <= 0)
            {
                Debug.Log("Player is currently idle");
            }
        }

        if(isRotating)
        {
            Debug.Log("Should be rotating");
            transform.Rotate(0, (h * rotateSpeed), 0);
        }

        if(isMoving)
        {
            Debug.Log("Should be moving");
            transform.Translate(0, 0, (v * moveSpeed));
        }
        
    }
}
