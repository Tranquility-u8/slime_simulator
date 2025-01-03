using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class Entity
{
    #region members
    
    [JsonProperty]
    public int id;
    
    [JsonProperty]
    public string name;

    [Header("Position")] 
    
    public Zone zone;
    
    public Cube cube;
    
    public bool IsOnZone => zone != null;
    
    [Header("Generated while gaming")]
    public GameObject gameObject;
    
    public SpriteRenderer sr;
    
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
    
    public virtual void UpdateSortingOrder()
    {
        sr.sortingOrder = cube.y * -1 + cube.z * 1000 - 5000;
    }
    
    #endregion
}
