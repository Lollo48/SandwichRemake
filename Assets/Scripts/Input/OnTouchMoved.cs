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

            if (direction != Vector2.zero)
            {
                SandwitchTile neighbour = GetNeighbours(nextPosition);

                if (neighbour != null && neighbour.pieces.Count > 0)
                {
                    //Debug.Log(neighbour);

                    Swipe(context.ObjectToSwipe, neighbour);

                    CalculateRightY(neighbour);

                    CheckWinCondition(neighbour);

                    context.InputStateMachine.ChangeState(context.onTouchIdle);
                }
                else context.InputStateMachine.ChangeState(context.onTouchIdle);
            }
        }
        else
        {
            context.InputStateMachine.ChangeState(context.onTouchIdle);
        }
    }


    private void CheckWinCondition(SandwitchTile neighbour)
    {
        if (neighbour.pieces[neighbour.pieces.Count - 1].Type == IngreditType.Bread && neighbour.pieces[0].Type == IngreditType.Bread && neighbour.pieces.Count == LevelManager.PiecesInGame)
        {
            Debug.Log("Winnnnn");
        }
    }
   

    private void CalculateRightY(SandwitchTile neighbour)
    {
        //neighbour.pieces.Count = 2 nel primo ciclo 
        // i = neighbour.pieces.Count - 1   -----> 1
        //
        
        for (int i = neighbour.pieces.Count -1 ; i >= 0; i--)
        {
            neighbour.pieces[i].transform.position = new Vector3(neighbour.pieces[i].XValue, 0.36f * i, neighbour.pieces[i].YValue);
        }

      


    }

    private void Swipe(SwipableObject objectToSwipe,SandwitchTile neighbour)
    {

        SandwitchTile CurrentTile = grid.GetGridObject(objectToSwipe.XValue, objectToSwipe.YValue);

        CurrentTile.pieces.Reverse();

        neighbour.AddToStack(CurrentTile.pieces);
        //Debug.Log(neighbour.pieces.Count);

        Vector3 newPosition = new Vector3(neighbour.x, 0f, neighbour.y);

        if (CurrentTile.pieces.Count != 0 )
        {
            foreach (SwipableObject swipableObject in CurrentTile.pieces)
            {
                swipableObject.transform.position = newPosition;

                swipableObject.XValue = neighbour.x;
                swipableObject.YValue = neighbour.y;
                swipableObject.AddNewPosition(newPosition);
            }
        }

        CurrentTile.ClearStack();
    }


    private SandwitchTile GetNeighbours(Vector2 nextPosition) => grid.GetGridObject(nextPosition);

    private Vector2 GetNextPosition(Vector2 previusPosition, Vector2 direction) => previusPosition + direction;

    private Vector2 GetTouchPosition(SwipableObject swipableObject) => new Vector2(swipableObject.XValue, swipableObject.YValue);

    private Vector2 GetDirection(Touch touch)
    {
        Vector2 delta = touch.deltaPosition;
        if (Mathf.Abs(delta.x) <= 0.5f && Mathf.Abs(delta.y) <= 0.5f)
            return Vector2.zero;

        else if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
            // | = - "assegnazione" | ? - "se vero" | : - "se falso" |
            return (delta.x > 0) ? Vector2.right : Vector2.left;
        else
            return (delta.y > 0) ? Vector2.up : Vector2.down;

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
