using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.StateMachine;

namespace Game.Manager
{

    public class InGameManager : Manager<InGameManager>
    {
        #region Fields

        /// <summary>
        /// Backing field of InGameState
        /// </summary>
        [SerializeField]
        private InGameStateMachine.InGameState _InGameState = InGameStateMachine.NULL;

        #endregion Fields

        #region Properties

        public InGameStateMachine.InGameState InGameState
        {
            get
            {
                return this._InGameState;
            }
            set
            {
                if (this._InGameState == value)
                    return;

                this.OnInGameStateChange(value);
                this._InGameState = value;
            }
        }

        #endregion Properties

        #region InGameManager
        /// <summary>
        /// OnInGameStateChange
        /// </summary>
        private void OnInGameStateChange(InGameStateMachine.InGameState newValue)
        {
            // Check InGameState machine: https://cacoo.com/diagrams/51VtjGisyx8bEBSt
            if (newValue.PreviousStates.Contains(this.InGameState))
            {
                return;
            }
            else
                throw new System.ArgumentException(string.Format("{0} to {1} doest not meet the InGameState machine.", this._InGameState.Name, newValue.Name));
        }

        #endregion InGameManager

        #region MonoBehavior

        #endregion MonoBehavior

        #region Manager

        /// <summary>
        /// Return instance of current class. DO: T.Instance = this;
        /// </summary>
        protected override void SetInstance()
        {
            InGameManager.Instance = this;
        }

        /// <summary>
        /// Return instance of current class. DO: T.Instance = null;
        /// </summary>
        protected override void ReleaseInstance()
        {
            InGameManager.Instance = null;
        }

        #endregion Manager
    }
}

