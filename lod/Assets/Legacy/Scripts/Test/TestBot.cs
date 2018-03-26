using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Manager;
using Game.StateMachine;

namespace Test
{
    public class TestBot : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
                InGameManager.Instance.InGameState = InGameStateMachine.LOADING;
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                InGameManager.Instance.InGameState = InGameStateMachine.PLAYING;
            else if (Input.GetKeyDown(KeyCode.Alpha3))
                InGameManager.Instance.InGameState = InGameStateMachine.PAUSING;
            else if (Input.GetKeyDown(KeyCode.Alpha4))
                InGameManager.Instance.InGameState = InGameStateMachine.ENDING;
            else if (Input.GetKeyDown(KeyCode.Alpha0))
                InGameManager.Instance.InGameState = InGameStateMachine.NULL;
        }
    }
}

