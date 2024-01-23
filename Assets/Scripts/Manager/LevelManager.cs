using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private LevelDataSO _levelData;

    public LevelDataSO LevelData { get => _levelData; }

    private Grid<SandwitchTile> _grid;
    public Grid<SandwitchTile> Grid { get => _grid; }

    private void Awake()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {

        _grid = new Grid<SandwitchTile>(_levelData.GridWidth, _levelData.GridHeight, 1, transform.position, (int x, int y) => new SandwitchTile(x, y));
        for (int i = 0; i < _levelData.GridWidth; i++)
        {
            for (int j = 0; j < _levelData.GridHeight; j++)
            {
                List<Piece> tmp = new List<Piece>();

                if (_levelData.BreadPositions.Contains(new Vector2(i, j)))
                    tmp.Add(new Piece(PieceType.Bread));
                else if (_levelData.PiecePosition.Contains(new Vector2(i, j)))
                    tmp.Add(new Piece(PieceType.Piece));

                _grid.GetGridObject(i, j).AddToList(tmp);
            }
        }
    }


    private void OnDrawGizmos()
    {
        Vector3 pos0 = new Vector3();
        Vector3 pos1 = new Vector3();
        for (int i = 0; i < _levelData.GridWidth + 1; i++)
        {
            pos0.x = i;
            pos0.z = 0;
            pos1.x = i;
            pos1.z = _levelData.GridHeight;
            Gizmos.color = Color.red;
            Gizmos.DrawLine(pos0, pos1);
        }

        for (int i = 0; i < _levelData.GridHeight + 1; i++)
        {
            pos0.x = 0;
            pos0.z = i;
            pos1.x = _levelData.GridWidth;
            pos1.z = i;
            Gizmos.color = Color.red;
            Gizmos.DrawLine(pos0, pos1);
        }

    }




}

public class Piece
{
    private PieceType _type;

    public PieceType Type { get => _type; }

    public Piece(PieceType type)
    {
        _type = type;
    }
}

public enum PieceType
{
    Bread,
    Piece
}