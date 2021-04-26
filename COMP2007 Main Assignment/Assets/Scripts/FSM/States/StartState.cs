using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Assets.Scripts.FSM.Interfaces;

namespace Assets.Scripts.FSM.States
{
    public class StartState : IBaseState
    {
        private StateManager stateManager;
        private Scene scene;

        public StartState(StateManager stateManagerRef)
        {
            stateManager = stateManagerRef;
            scene = SceneManager.GetActiveScene();

            if(scene.name != "StartState")
            {
                SceneManager.LoadScene("StartScene");
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
}