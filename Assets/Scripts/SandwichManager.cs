using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwichManager : MonoBehaviour
{
    public List<SandwitchWorldTile> WordTilePrefabs = new List<SandwitchWorldTile>();


    public int Width;
    public int Height;

    private Grid<SandwichTile> m_grid;
    private List<SandwitchWorldTile> m_worldTiles;


    private SandwichTile ReturnMemoryTile(int x, int y)
    {
        return new SandwichTile(x, y);
    }


    private void Awake()
    {
        GeneratePuzzle();
    }


    private void GeneratePuzzle()
    {

        m_grid = new Grid<SandwichTile>(Width, Height, WordTilePrefabs[0].transform.lossyScale.x, transform.position, ReturnMemoryTile);
       m_worldTiles = new();

        int index = 0;

        for (int y = 0; y < m_grid.GetHeight(); y++)
        {
            for (int x = 0; x < m_grid.GetWidth(); x++)
            {

               SandwitchWorldTile worldTile = Instantiate(WordTilePrefabs[index], m_grid.GetWorldPosition(x, y), Quaternion.identity, transform);

                worldTile.SetGridManager(m_grid);

                m_worldTiles.Add(worldTile);

                worldTile.SetTileData(m_grid.GetGridObject(x, y));

                worldTile.SetID(index);

                if (x % 2 != 0)
                {
                    index++;
                }
            }
        }

    }
}

