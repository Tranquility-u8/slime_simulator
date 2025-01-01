using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class Location
{
    #region members

    [JsonProperty]
    [Tooltip("Zone or Atlas")]
    public bool IsOnZone = true;
    
    [JsonProperty]
    public GridBase grid;

    [JsonProperty]
    public int x;
    
    [JsonProperty]
    public int y;
    
    [JsonProperty]
    public int z;

    #endregion

    public Location(GridBase _grid, int _x, int _y, int _z)
    {
        grid = _grid;
        x = _x;
        y = _y;
        z = _z;
    }
}