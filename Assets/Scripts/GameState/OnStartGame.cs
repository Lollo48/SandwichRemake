using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnStartGame : StateBase<FlowGameManager>
{
    public OnStartGame(string stateID, StatesMachine<FlowGameManager> statesMachine) : base(stateID, statesMachine)
    {

    }
    public override void OnEnter(FlowGameManager contex)
    {
        base.OnEnter(contex);


    }

    public override void OnExit(FlowGameManager contex)
    {
        base.OnExit(contex);

    }
}
