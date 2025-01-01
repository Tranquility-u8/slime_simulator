using UnityEngine;
using Newtonsoft.Json;

public abstract class GridBase
{
    [JsonProperty]
    public string name;
    
    [Header("Render params")]
    [JsonProperty] 
    public Vector2Int renderAnchor = new Vector2Int(0, 0);
    
    [JsonProperty] 
    public int renderSize = 1;
    
    public virtual void Render(){}
}

public enum Direction
{
    North,
    East,
    South,
    West,
}