using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Levels", menuName = "New Level")]
public class LevelData : ScriptableObject
{
    [SerializeField] private List<Vector2> breadPositions;
    [SerializeField] private List<Vector2> commonPiece;
    [SerializeField] private GameObject pieceToSpawn;


    public List<Vector2> BreadPositions { get => breadPositions; }
    public List<Vector2> CommonPiece { get => commonPiece; }

    public GameObject PieceToSpawn { get => pieceToSpawn; set => pieceToSpawn = value; }

}
