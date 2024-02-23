using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchIdle : StateBase<InputManager>
{
    public OnTouchIdle(string stateID, StatesMachine<InputManager> statesMachine) : base(stateID, statesMachine)
    {

    }

    public override void OnEnter(InputManager context)
    {
        base.OnEnter(context);
        
    }

    public override void OnUpdate(InputManager context)
    {
        base.OnUpdate(context);
        
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            context.InputStateMachine.ChangeState(context.onTouchBegan);
        }

    }
}
