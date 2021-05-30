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
                if(h > 0)
                {
                    Debug.Log("Should rotate right");
                    transform.Rotate(0, transform.rotation.eulerAngles.y + (h * rotateSpeed), 0);
                }
                
                else if(h < 0)
                {
                    Debug.Log("Should rotate left");
                    transform.Rotate(0, transform.rotation.eulerAngles.y - (h * rotateSpeed), 0);
                }
            }

            else if(Input.GetButtonDown("Vertical")) 
            {
                transform.Translate(0, 0, transform.position.z + (v * moveSpeed));
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
        
    }
}
