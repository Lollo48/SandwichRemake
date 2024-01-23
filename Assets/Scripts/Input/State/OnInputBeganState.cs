using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnInputBeganState : StateBase<InputStateManager>
{
    public OnInputBeganState(string stateID, StatesMachine<InputStateManager> statesMachine) : base(stateID, statesMachine)
    {

    }

    public override void OnEnter(InputStateManager contex)
    {
        base.OnEnter(contex);


    }

    public override void OnExit(InputStateManager contex)
    {
        base.OnExit(contex);

    }
}
