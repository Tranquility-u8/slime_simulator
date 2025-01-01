using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class Entity
{
    #region members
    
    [JsonProperty]
    public Location location;
    
    [JsonProperty]
    public int id;
    
    [JsonProperty]
    public string name;
    
    #endregion
    
    #region methods
    
    public virtual void Advance()
    {
    }
    
    #endregion
}
