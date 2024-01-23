using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwitchTile : Tile
{

    private List<Piece> _swipableObject;

    public List<Piece> SwipableObject
    {
        get { return _swipableObject; }
        set { _swipableObject = value; }
    }

    public SandwitchTile(int x, int y) : base(x,y)
    {

    }

    public void AddToList(List<Piece> piece)
    {
        if (_swipableObject == null)
            _swipableObject = new List<Piece>();

        foreach (Piece ing in piece)
            _swipableObject.Add(ing);
    }

}
