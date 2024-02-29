using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [HideInInspector] public SwipableObject ObjectToSwipe;

    private StatesMachine<InputManager> inputStateMachine;

    public StatesMachine<InputManager> InputStateMachine { get => inputStateMachine; }

    public OnTouchIdle onTouchIdle;
    public OnTouchBegan onTouchBegan;
    public OnTouchMoved onTouchMoved;
    public OnTouchEnded onTouchEnded;



    private void Start()
    {
        InitStateMachine();
    }


    private void InitStateMachine()
    {
        inputStateMachine = new StatesMachine<InputManager>(this);
        onTouchBegan = new OnTouchBegan("onTouchBegan", inputStateMachine);
        onTouchIdle = new OnTouchIdle("onTouchIdle", inputStateMachine);
        onTouchMoved = new OnTouchMoved("onTouchMoved", inputStateMachine);
        onTouchEnded = new OnTouchEnded("onTouchEnded", inputStateMachine);
        inputStateMachine.RunStateMachine(onTouchIdle);

    }



    private void Update()
    {
        inputStateMachine.CurrentState.OnUpdate(this);
    }


   


}
