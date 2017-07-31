using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Manager
{
    public enum InGameState
    {
        NULL    = 0,    // Always start from NULL
        LOADING = 1,
        PLAYING = 2,
        PAUSING = 3,    // Only be able to save when under PAUSE state
        ENDING  = 4
    }
    public class InGameManager : Manager<InGameManager>
    {
        #region Fields

        /// <summary>
        /// Backing field of InGameState
        /// </summary>
        [SerializeField]
        private InGameState _InGameState = InGameState.NULL;

        #endregion Fields

        #region Properties

        public InGameState InGameState
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
        private void OnInGameStateChange(InGameState newValue)
        {
            // Check InGameState machine: https://cacoo.com/diagrams/51VtjGisyx8bEBSt
            if (this._InGameState == InGameState.NULL && newValue == InGameState.LOADING
                || (this._InGameState == InGameState.LOADING && newValue == InGameState.PLAYING)
                || (this._InGameState == InGameState.PLAYING && (newValue == InGameState.PAUSING || newValue == InGameState.ENDING))
                || (this._InGameState == InGameState.PAUSING && newValue == InGameState.PLAYING)
                || (this._InGameState == InGameState.ENDING && newValue == InGameState.NULL))
            {
                return;
            }
            else
                throw new System.ArgumentException(string.Format("{0} to {1} doest not meet the InGameState machine.", this._InGameState, newValue));
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

