using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipableObject : MonoBehaviour
{
    private IngreditType type;
    private int xValue;
    private int yValue;

    public List<Vector3> Positions = new List<Vector3>();



    public IngreditType Type { get => type; set => type = value; }
    public int XValue { get => xValue; set => xValue = value; }
    public int YValue { get => yValue; set => yValue = value; }


    public void init(IngreditType type,int x , int y,Vector3 position)
    {
        this.type = type;
        xValue = x;
        yValue = y;
        Positions.Add(position);
    }

    public void AddNewPosition(Vector3 newPosition)
    {
        Positions.Add(newPosition);

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