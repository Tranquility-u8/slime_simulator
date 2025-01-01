using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class Cell3d : BaseCell
{
    
    #region members
    
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
    

    #endregion
}