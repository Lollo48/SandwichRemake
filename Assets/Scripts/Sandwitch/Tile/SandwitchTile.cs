using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwitchTile : Tile
{

    public List<SwipableObject> pieces;


    public SandwitchTile(int x, int y) : base(x, y)
    {
        
    }


    public void AddToStack(List<SwipableObject> pieces)
    {
        if (this.pieces == null)
            this.pieces = new List<SwipableObject>();

        foreach (SwipableObject piece in pieces)
            this.pieces.Add(piece);
    }

    public void ClearStack()
    {
        pieces.Clear();
        x = 0;
        y = 0;
     
    }

}
