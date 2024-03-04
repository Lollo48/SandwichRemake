using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UndoManager : MonoBehaviour
{
    public List<InverseMoves> InverseMoves = new List<InverseMoves>();


    private void OnEnable()
    {
        OnTouchMoved.OnRegister += Register;
        UIManager.OnTryUndo += TryUndo;
    }

    private void OnDisable()
    {
        OnTouchMoved.OnRegister -= Register;
        UIManager.OnTryUndo -= TryUndo;
    }

    private void Register(SandwitchTile swipableObject, SandwitchTile sandwitchTile)
    {
        InverseMoves newInverseMove = new InverseMoves(swipableObject, sandwitchTile);
        InverseMoves.Add(newInverseMove);
    }


    private void TryUndo()
    {
        if (InverseMoves.Count == 0) return;

        InverseMoves inverseMoves = InverseMoves[^1];

        List<SwipableObject> NewPieces = inverseMoves.TileA.pieces;

        NewPieces.RemoveAt(0);

        //NewPieces.Reverse();

        inverseMoves.TileA.pieces.RemoveRange(1, inverseMoves.TileA.pieces.Count - 1);

        inverseMoves.TileB.AddToStack(NewPieces);

        Vector3 newPosition = new Vector3(inverseMoves.TileB.x, 0f, inverseMoves.TileB.y);

        for (int i = 0; i < NewPieces.Count; i++)
        {
            NewPieces[i].transform.position = newPosition;
            NewPieces[i].XValue = inverseMoves.TileB.x;
            NewPieces[i].YValue = inverseMoves.TileB.y;

        }

        CalculateRightY(inverseMoves.TileB);

        InverseMoves.RemoveAt(InverseMoves.Count - 1);
    }


    private void CalculateRightY(SandwitchTile neighbour)
    {

        for (int i = neighbour.pieces.Count - 1; i >= 0; i--)
        {
            neighbour.pieces[i].transform.position = new Vector3(neighbour.pieces[i].XValue, 0.1f * i, neighbour.pieces[i].YValue);
        }

    }

}
