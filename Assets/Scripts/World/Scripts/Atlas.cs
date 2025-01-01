using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using UnityEngine;

public class Atlas : Grid2d<Tile>
{
    #region members

    [JsonProperty]
    public string name;
    
    [JsonProperty]
    public Vector2 size;

    #endregion
}