using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPiece", menuName = "Scriptable Objects/Level")]
public class LevelDataSO : ScriptableObject
{
    [SerializeField] private int _gridWidth;
    [SerializeField] private int _gridHeight;
    [SerializeField] private GameObject _piece;
    [SerializeField] private List<Vector2> _breadPositions;
    [SerializeField] private List<Vector2> _piecePosition;



    public GameObject Piece { get => _piece; }
    public int GridWidth { get => _gridWidth; }
    public int GridHeight { get => _gridHeight; }

    public List<Vector2> BreadPositions { get => _breadPositions; }
    public List<Vector2> PiecePosition { get => _piecePosition; }
}
