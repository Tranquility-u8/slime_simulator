using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

[ES3Serializable]
public class World
{
    #region members
    
    public string name;
    
    public List<Atlas> atlases;

    #endregion

    #region methods
    
    public World()
    {
        // Test
        name = "DefaultWorld";
        Atlas mainland = new Atlas();
        atlases = new List<Atlas>();
        atlases.Add(mainland);
        
        Zone village = new Zone("Village");
        mainland.zones[village.name] = village;

    }
    

    #endregion
    
}
