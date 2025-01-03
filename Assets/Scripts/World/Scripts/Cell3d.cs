using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using UnityEngine;

public class Cell3d : CellBase
{
    
    #region members
    
    [Header("Position in grid")]
    [JsonProperty]
    public int x;
    
    [JsonProperty]
    public int y;
    
    [JsonProperty]
    public int z;
    
    #endregion

    #region methods

    public Vector3Int GetPosition()
    {
        return new Vector3Int(x, y, z);
    }
    
    public virtual bool IsEmpty()
    {
        throw new System.NotImplementedException();
    }

    
    #endregion
}