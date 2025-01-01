using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class Cell2d : BaseCell
{
    #region members
    
    [JsonProperty]
    public int x;
    
    [JsonProperty]
    public int y;
    
    #endregion

    #region methods

    public Vector2Int GetPosition()
    {
        return new Vector2Int(x, y);
    }
    

    #endregion
}
