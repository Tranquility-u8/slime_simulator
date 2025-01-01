using UnityEngine;
using Newtonsoft;
using Newtonsoft.Json;

public class Tile : Cell2d
{
    #region members
    
    [JsonProperty]
    public string TileType;

    [JsonProperty]
    public int direction;
    
    private SpriteRenderer sr;
    
    public GameObject gameObject;
    #endregion
    
}
