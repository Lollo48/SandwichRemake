using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwitchTile : Tile
{

    public List<GameObject> pieces;


    public SandwitchTile(int x, int y) : base(x, y)
    {
        
    }


    public void AddToStack(List<GameObject> pieces)
    {
        if (this.pieces == null)
            this.pieces = new List<GameObject>();

        foreach (GameObject piece in pieces)
            this.pieces.Add(piece);
    }


    public void RemoveToStack(GameObject piece)
    {
        if (pieces.Contains(piece)) pieces.Remove(piece);
    }

    public void ClearStack()
    {
        pieces.Clear();
    }

}
