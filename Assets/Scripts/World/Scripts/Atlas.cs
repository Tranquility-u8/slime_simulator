using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ES3Types;
using Newtonsoft.Json;
using UnityEngine;

public class Atlas : Grid2d<Tile>
{
    #region members
    
    public Vector2 size;
    
    public Dictionary<string, Zone> zones = new Dictionary<string, Zone>();

    #endregion
}