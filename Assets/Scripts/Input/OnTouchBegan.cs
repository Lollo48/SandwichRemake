using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTouchBegan : StateBase<InputManager>
{

    public Camera camera;
    

    public OnTouchBegan(string stateID, StatesMachine<InputManager> statesMachine) : base(stateID, statesMachine)
    {
        camera = Camera.main;
    }

    public override void OnUpdate(InputManager context)
    {
        base.OnUpdate(context);
        
        if (Input.touchCount == 1 )
        {
            //raycast telecamera e controlli
            Touch touch = Input.GetTouch(0);
            context.ObjectToSwipe = TryGetPiece(touch.position);

            if(context.ObjectToSwipe!=null)
            {
                context.InputStateMachine.ChangeState(context.onTouchMoved);
                //Debug.Log(context.ObjectToSwipe);
            }
            else
            {
                //Debug.Log(context.ObjectToSwipe);
                context.InputStateMachine.ChangeState(context.onTouchIdle);
            }
        }
        else
        {
            context.InputStateMachine.ChangeState(context.onTouchIdle);
        }
    }


    private SwipableObject TryGetPiece(Vector2 position)
    {
        Ray ray = camera.ScreenPointToRay(position);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent(out SwipableObject swipableObject))
            {
                
                return swipableObject;
            }
            else return null;
        }
        else return null;
    }

}
