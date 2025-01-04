using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    
    public Cell3d GetCell(Vector3Int pos)
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
    
    public bool IsNearEmpty(Cell3d cell, int direction)
    {
        Vector3Int target = cell.GetPosition() + ActionHelper.DirectionVec3[(int)direction];
        if(IsValidCell(target)) return true;

        return false;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]  
    public bool IsValidCell(int x, int y, int z)
    {
        if(x >= 0 && x < sizeX && y >= 0 && y < sizeY && z >= 0 && z < sizeZ) return true;
        //Debug.LogWarning("Invalid block position");
        return false;
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]  
    public bool IsValidCell(Vector3Int pos)
    {
        if(pos.x >= 0 && pos.x < sizeX && pos.y >= 0 && pos.y < sizeY && pos.z >= 0 && pos.z < sizeZ) return true;
        //Debug.LogWarning("Invalid block position");
        return false;
    }

    public static float GetDistanceBetweenCells(Cell3d cell1, Cell3d cell2)
    {
        return Vector3Int.Distance(cell1.GetPosition(), cell2.GetPosition());
    }
    
    #endregion
}