using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwichTile : Tile
{
    public int ID;

    public List<SandwitchWorldTile> sandwichTiles = new List<SandwitchWorldTile>();

    public SandwichTile(int x, int y) : base(x, y) { }



}
