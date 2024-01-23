using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTileManager : MonoBehaviour
{
    [SerializeField] private LevelManager _levelManager;


    public void GenerateTiles()
    {

        for (int i = 0; i < _levelManager.LevelData.GridWidth; i++)
        {
            for (int j = 0; j < _levelManager.LevelData.GridHeight; j++)
            {
                for (int x = 0; x < _levelManager.Grid.GetGridObject(i, j).SwipableObject.Count; x++)
                {
                    Vector3 pos = _levelManager.Grid.GetWorldPosition(i, j);
                    pos = new Vector3(pos.x, x * 0.3f, pos.z);

                    Color tmp = Color.cyan;

                    if (_levelManager.Grid.GetGridObject(i, j).SwipableObject[x].Type == PieceType.Bread)
                        tmp = Color.black;

                    if (_levelManager.Grid.GetGridObject(i, j).SwipableObject[x].Type == PieceType.Piece)
                        tmp = Color.blue;

                    GameObject go = Instantiate(_levelManager.LevelData.Piece, pos, Quaternion.identity);
                    go.GetComponent<MeshRenderer>().material.color = tmp;
                }
            }
        }
    }


}
