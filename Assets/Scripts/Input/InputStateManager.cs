using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputStateManager : MonoBehaviour
{

    private StatesMachine<InputStateManager> _inputStateMachine;
    private InputManager _inputManager;
    public InputManager InputManager { get => _inputManager; set => _inputManager = value; }

    #region STATE
    public OnInputIdleState IdleState;
    public OnInputBeganState BeganState;
    public OnInputMovedState MovedState;
    public OnInputEndedState EndedState;
    #endregion
    private void Awake()
    {
        InitStateMachine();
        _inputManager = GetComponentInChildren<InputManager>();
    }

    private void Update() => _inputStateMachine.CurrentState.OnUpdate(this);


    private void InitStateMachine()
    {
        _inputStateMachine = new StatesMachine<InputStateManager>(this);
        IdleState = new OnInputIdleState("IdleState", _inputStateMachine);
        BeganState = new OnInputBeganState("beganState", _inputStateMachine);
        MovedState = new OnInputMovedState("MovedState", _inputStateMachine);
        EndedState = new OnInputEndedState("EndedState", _inputStateMachine);
        

        _inputStateMachine.RunStateMachine(IdleState);
    }


    private void SetState()
    {
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began) { _inputStateMachine.ChangeState(BeganState); }
            else if (touch.phase == TouchPhase.Moved)
            {
                _inputStateMachine.ChangeState(MovedState);
                
            }
            else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                _inputStateMachine.ChangeState(EndedState);
                
            }
            

        }
        else { _inputStateMachine.ChangeState(IdleState);  }
    }

    public Touch GetTouch(int index)
    {
        return Input.GetTouch(index);
    }
}
