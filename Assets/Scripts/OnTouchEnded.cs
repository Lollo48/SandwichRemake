using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchEnded : StateBase<InputManager>
{
    public OnTouchEnded(string stateID, StatesMachine<InputManager> statesMachine) : base(stateID, statesMachine)
    {

    }


}
