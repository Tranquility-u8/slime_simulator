using UnityEngine;
using Newtonsoft;
using Newtonsoft.Json;

public class Block : Cell
{
    #region members
    
    [JsonProperty]
    public int z;
    
    [JsonProperty]
    public string tileType;

    [JsonProperty]
    public int direction;
    
    private SpriteRenderer sr;
    
    public GameObject gameObject;
    
    
    #endregion

    

    #region methods
    
    public Vector3Int GetPositionVec3()
    {
        return new Vector3Int(x, y, z);
    }
    

    #endregion
}

public enum Direction
{
    North,
    East,
    South,
    West,
}