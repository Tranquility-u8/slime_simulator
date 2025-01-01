using UnityEngine;
using Newtonsoft.Json;

public abstract class GridBase
{
    public virtual void Render(){}

    [Header("Render params")]
    [JsonProperty] 
    public Vector2Int renderAnchor = new Vector2Int(0, 0);
    
    [JsonProperty] 
    public int renderSize = 16;
    
}

public enum Direction
{
    North,
    East,
    South,
    West,
}