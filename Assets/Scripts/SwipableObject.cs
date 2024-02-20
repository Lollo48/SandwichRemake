using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipableObject : MonoBehaviour
{
    private IngreditType type;

    public IngreditType Type { get => type; set => type = value; }
}

public enum IngreditType
{
    Bread,
    Piece
}