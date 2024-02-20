using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwitchTile : Tile
{

    public List<GameObject> piece;


    public SandwitchTile(int x, int y) : base(x, y)
    {
        
    }


    public void AddToStack(List<GameObject> pieces)
    {
        if (this.piece == null)
            this.piece = new List<GameObject>();

        foreach (GameObject piece in pieces)
            this.piece.Add(piece);
    }

    public void ClearStack()
    {
        piece.Clear();
    }

}
