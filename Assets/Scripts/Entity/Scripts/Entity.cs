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
    
    public virtual void Update()
    {
    }

    public virtual void Advance()
    {
        
    }

    public virtual void Render(int _renderSize)
    {
        
    } 
    
    #endregion
}
