using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
    public float moveSpeed;

    public float idleTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        if(Input.anyKey)
        {
            if(Input.GetButtonDown("Horizontal"))
            {
                transform.rotation.eulerAngles.y += (h * moveSpeed);
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
