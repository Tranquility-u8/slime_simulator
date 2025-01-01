using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft;
using Newtonsoft.Json;

public class Grid2d<T> : GridBase where T : Cell2d
{
    #region members

    [JsonProperty]
    public string id;
    
    [JsonProperty] 
    public int sizeX;

    [JsonProperty] 
    public int sizeY;
    
    [JsonProperty]
    public T[,] grid;
    
    #endregion
    
    #region methods

    public Cell2d getCell(Vector2Int pos)
    {
        if (grid == null)
        {
            Debug.Log("Grid2d<" + typeof(T).Name + "> grid is null");
            return null;
        }
        return grid[pos.x, pos.y];
    }
    
    public static T FindNearestPoint()
    {
        return null as T;
    }
    
    #endregion
}