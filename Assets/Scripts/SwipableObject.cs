using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipableObject : MonoBehaviour
{
    private IngreditType type;
    private int xValue;
    private int yValue;

    private SandwitchTile tile;

    public IngreditType Type { get => type; set => type = value; }
    public int XValue { get => xValue; set => xValue = value; }
    public int YValue { get => yValue; set => yValue = value; }
    public SandwitchTile Tile { get => tile; set => tile = value; }


    public void init(IngreditType type,int x , int y)
    {
        this.type = type;
        xValue = x;
        yValue = y;
    }

   


}

public enum IngreditType
{
    Bread,
    Piece
}