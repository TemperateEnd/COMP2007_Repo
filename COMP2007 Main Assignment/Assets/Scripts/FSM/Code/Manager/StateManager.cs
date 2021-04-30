﻿using System.Collections;
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
        if(instanceRef != null) //If something already exists, destroy the GameObject
        {
            DestroyImmediate(gameObject);
        }

        else
        {
            instanceRef = this;
            DontDestroyOnLoad(instanceRef);
            InstanceRef = instanceRef;
        }
    }

    // Start is called before the first frame update
    private void Start()
    {
        IActiveState = new StartState(this);
    }

    // Update is called once per frame
    private void Update()
    {
        if(IActiveState != null)
        {
            IActiveState.StateUpdate();
        }
    }

    public void SwitchState(IBaseState nextState)
    {
        IActiveState = nextState;
    }
}