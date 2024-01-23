using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowGameManager : MonoBehaviour
{

    private StatesMachine<FlowGameManager> StateMachine;




    #region STATE
    public OnStartGame OnStartGame;
    #endregion


    private void Awake()
    {
        InitStateMachine();
    }

    private void Update() => StateMachine.CurrentState.OnUpdate(this);


    private void InitStateMachine()
    {
        StateMachine = new StatesMachine<FlowGameManager>(this);
        OnStartGame = new OnStartGame("OnStartGame", StateMachine);

        StateMachine.RunStateMachine(OnStartGame);
    }

}
