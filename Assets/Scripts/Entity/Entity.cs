using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class Entity : IEntityParent
{
    #region members
    
    [JsonProperty]
    public int id;
    
    #endregion
    
    #region methods
    
    public virtual void Advance()
    {
    }
    
    #endregion
}