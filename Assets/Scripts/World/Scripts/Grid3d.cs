using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft;
using Newtonsoft.Json;

public class Grid3d<T> : GridBase where T : Cell3d
{
    #region members
    
    [JsonProperty] 
    public int sizeX;
    
    [JsonProperty] 
    public int sizeY;
    
    [JsonProperty] 
    public int sizeZ;
    
    [JsonProperty]
    public T[ , , ] grid;
    
    #endregion
    
    #region methods

    public override void Render()
    {
        
    }
    
    public Cell3d getCell(Vector3Int pos)
    {
        if (grid == null)
        {
            Debug.Log("Grid2d<" + typeof(T).Name + "> grid is null");
            return null;
        }
        return grid[pos.x, pos.y, pos.z];
    }
    public static T FindNearestPoint()
    {
        return null as T;
    }
    
    #endregion
}