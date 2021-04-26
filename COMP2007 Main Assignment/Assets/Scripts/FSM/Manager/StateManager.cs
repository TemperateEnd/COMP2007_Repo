using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// First attempt at implementing my own Finite State Machine (in any and all works linked to this
/// assignment, we will be using the FSM abbrieviation when refering to this).
///</summary>

public class StateManager : MonoBehaviour
{
    private IBaseState IActiveState;

    public static StateManager InstanceRef = null;
    private static StateManager instanceRef;

    private void Awake() 
    {
        if(instanceRef != null)
        {
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
