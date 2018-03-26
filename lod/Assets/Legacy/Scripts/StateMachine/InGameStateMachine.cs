using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.StateMachine
{

    public class InGameStateMachine
    {
        public class InGameState
        {
            public string Name;
            public List<InGameState> PreviousStates;
            public InGameState(string name)
            {
                this.Name = name;
                this.PreviousStates = new List<InGameState>();
            }

            public InGameState(string name, List<InGameState> previousStates)
            {
                this.Name = name;
                this.PreviousStates = new List<InGameState>();
                this.PreviousStates.AddRange(previousStates);
            }
        }

        static private InGameState _NULL    = new InGameState("NULL", new List<InGameState> { _ENDING });
        static private InGameState _LOADING = new InGameState("LOADING", new List<InGameState> { _NULL });
        static private InGameState _PLAYING = new InGameState("PLAYING", new List<InGameState> { _LOADING, _PAUSING });
        static private InGameState _PAUSING = new InGameState("PAUSING", new List<InGameState> { _PLAYING });
        static private InGameState _ENDING  = new InGameState("ENDING", new List<InGameState> { _PLAYING });

        static public InGameState NULL    { get { return _NULL; } }
        static public InGameState LOADING { get { return _LOADING; } }
        static public InGameState PLAYING { get { return _PLAYING; } }
        static public InGameState PAUSING { get { return _PAUSING; } }
        static public InGameState ENDING  { get { return _ENDING; } }
    }
}

