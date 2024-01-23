using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnInputEndedState : StateBase<InputStateManager>
{
    public OnInputEndedState(string stateID, StatesMachine<InputStateManager> statesMachine) : base(stateID, statesMachine)
    {

    }

    public override void OnEnter(InputStateManager contex)
    {
        base.OnEnter(contex);


    }
}
