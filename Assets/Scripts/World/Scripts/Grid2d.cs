using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft;
using Newtonsoft.Json;

public class Grid2d<T> : BaseGrid where T : Cell2d
{
    #region members

    [JsonProperty]
    public string id;
    
    [JsonProperty]
    List<Grid> children = new List<Grid>();
    
    #endregion
    
    #region methods

    public static T FindNearestPoint()
    {
        return null as T;
    }
    
    #endregion
}