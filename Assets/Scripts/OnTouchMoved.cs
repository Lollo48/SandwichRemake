using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OnTouchMoved : StateBase<InputManager>
{

    public static event Func<Grid<SandwitchTile>> GetGrid; // uguale action ma ritorna qualcosa
    private Grid<SandwitchTile> grid;
    Vector2 direction;
     
    public OnTouchMoved(string stateID, StatesMachine<InputManager> statesMachine) : base(stateID, statesMachine)
    {

    }


    public override void OnEnter(InputManager context)
    {
        base.OnEnter(context);
        grid = GetGrid.Invoke();
        //Debug.Log(grid);
    }

    public override void OnUpdate(InputManager context)
    {
        base.OnUpdate(context);

        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);

            direction = GetDirection(touch);
            Vector2 previusPosition = GetTouchPosition(context.ObjectToSwipe);

            Vector2 nextPosition = GetNextPosition(previusPosition, direction);
            if (direction != Vector2.zero)
            {
                SandwitchTile neighbour = TryGetNeighbours(nextPosition);

                if (neighbour != null && neighbour.pieces.Count > 0 && direction != Vector2.zero)
                {
                    Debug.Log(neighbour);
                    Swipe(context.ObjectToSwipe, neighbour);
                    context.InputStateMachine.ChangeState(context.onTouchIdle);
                    //context.InputStateMachine.ChangeState(context.onTouchEnded);
                }
                else context.InputStateMachine.ChangeState(context.onTouchIdle);
            }
        }
        else
        {
            context.InputStateMachine.ChangeState(context.onTouchIdle);
        }
    }

    public override void OnExit(InputManager context)
    {
        base.OnExit(context);
        direction = Vector2.zero;
    }



    private void Swipe(SwipableObject objectToSwipe,SandwitchTile neighbour)
    {

        Vector3 newPosition = new Vector3(neighbour.x, 0, neighbour.y);
        
        objectToSwipe.transform.position = newPosition;

    }



    private SandwitchTile TryGetNeighbours(Vector2 nextPosition)
    {
        SandwitchTile piece = grid.GetGridObject(nextPosition);
        return piece;
    }


    private Vector2 GetNextPosition(Vector2 previusPosition, Vector2 direction)
    {
        return previusPosition + direction;
    }

    private Vector2 GetTouchPosition(SwipableObject swipableObject)
    {
        return new Vector2(swipableObject.XValue, swipableObject.YValue);
    }


    private Vector2 GetDirection(Touch touch)
    {
        Vector2 delta = touch.deltaPosition;
        if (Mathf.Abs(delta.x) <= 1 && Mathf.Abs(delta.y) <= 1)
            return Vector2.zero;
        else if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
            // | = - "assegnazione" | ? - "se vero" | : - "se falso" |
            if (delta.x > 0) return Vector2.right;
            else return Vector2.left;
        else
            if (delta.y > 0) return Vector2.up;
        else return Vector2.down;
    }





}

public enum Direction
{
    Still,
    Left,
    Right,
    Up,
    Down
}
