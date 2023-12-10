using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwitchWorldTile : MonoBehaviour
{
    private Grid<SandwichTile> m_grid;

    SandwichTile m_data;

    


    public void SetTileData(SandwichTile memoryTile) => m_data = memoryTile;

    public int GetId() => m_data.ID;

    public int SetID(int value) => m_data.ID = value;

    public void SetGridManager(Grid<SandwichTile> g) => m_grid = g;




}
