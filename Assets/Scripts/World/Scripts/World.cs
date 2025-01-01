using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class World
{
    #region members
    
    [JsonProperty]
    public string name;
    
    [JsonProperty]
    public List<Atlas> atlases;

    [JsonProperty]
    public DateTime history;

    #endregion

    #region methods

    public World()
    {
        // Test
        Atlas mainland = new Atlas();
        atlases = new List<Atlas>();
        atlases.Add(mainland);
        
        Zone village = new Zone("Village");
        mainland.zones[village.name] = village;
    }
    

    #endregion
    
}
