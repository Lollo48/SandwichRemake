using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OnTouchMoved : StateBase<InputManager>
{

    public static event Func<Grid<SandwitchTile>> GetGrid; // uguale action ma ritorna qualcosa
    private Grid<SandwitchTile> grid;

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
            Vector2 direction = GetDirection(touch);
            Vector2 previusPosition = GetTouchPosition(context.ObjectToSwipe);

            Vector2 nextPosition = GetNextPosition(previusPosition, direction);
            SandwitchTile neighbour = TryGetNeighbours(nextPosition);

            Debug.Log(neighbour);

            //Debug.Log(direction);
            //controllo griglia e controllo cella di dove devo andare
            //preso il pezzo da onTouchBegan spostarlo nella nuova direzione
        }
        else
        {
            context.InputStateMachine.ChangeState(context.onTouchIdle);
        }
    }

    private void Swipe(SwipableObject objectToSwipe,SandwitchTile neighbour)
    {
        
       

    }



    private SandwitchTile TryGetNeighbours(Vector2 newxtPosition)
    {
        SandwitchTile piece = grid.GetGridObject(newxtPosition);
        if (piece == null || piece.piece.Count == 0) return null;
        else return piece;
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
