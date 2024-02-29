using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipableObject : MonoBehaviour
{
    private IngreditType type;
    private int xValue;
    private int yValue;


    public IngreditType Type { get => type; set => type = value; }
    public int XValue { get => xValue; set => xValue = value; }
    public int YValue { get => yValue; set => yValue = value; }


    public void init(IngreditType type,int x , int y)
    {
        this.type = type;
        xValue = x;
        yValue = y;

    }

    public void ClearLevel()
    {
        Destroy(gameObject);
    }


}

public enum IngreditType
{
    Bread,
    Piece
}


[System.Serializable]
public struct InverseMoves
{
    public SandwitchTile TileA;
    public SandwitchTile TileB;

    public InverseMoves(SandwitchTile me, SandwitchTile cameFrom)
    {
        TileA = me;
        TileB = cameFrom;

    }



}


