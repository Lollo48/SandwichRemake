using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnInputMovedState : StateBase<InputStateManager>
{
    public OnInputMovedState(string stateID, StatesMachine<InputStateManager> statesMachine) : base(stateID, statesMachine)
    {

    }

    public override void OnEnter(InputStateManager contex)
    {
        base.OnEnter(contex);
        

    }
}
