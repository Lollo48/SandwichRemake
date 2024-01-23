using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardTileManager : MonoBehaviour
{
    [SerializeField] private LevelManager _levelManager;

    private void Start()
    {
        GenerateTiles();
    }

    public void GenerateTiles()
    {

        for (int i = 0; i < _levelManager.LevelData.GridWidth; i++)
        {
            for (int j = 0; j < _levelManager.LevelData.GridHeight; j++)
            {
                for (int x = 0; x < _levelManager.Grid.GetGridObject(i, j).SwipableObject.Count; x++)
                {
                    Vector3 pos = _levelManager.Grid.GetWorldPosition(i, j);
                    pos = new Vector3(pos.x, x, pos.z);
                    GameObject go = Instantiate(_levelManager.LevelData.Piece, pos, Quaternion.identity);

                }
            }
        }
    }


}
