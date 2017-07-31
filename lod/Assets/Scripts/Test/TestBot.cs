using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Manager;

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
                InGameManager.Instance.InGameState = InGameState.LOADING;
            else if (Input.GetKeyDown(KeyCode.Alpha2))
                InGameManager.Instance.InGameState = InGameState.PLAYING;
            else if (Input.GetKeyDown(KeyCode.Alpha3))
                InGameManager.Instance.InGameState = InGameState.PAUSING;
            else if (Input.GetKeyDown(KeyCode.Alpha4))
                InGameManager.Instance.InGameState = InGameState.ENDING;
            else if (Input.GetKeyDown(KeyCode.Alpha0))
                InGameManager.Instance.InGameState = InGameState.NULL;
        }
    }
}

