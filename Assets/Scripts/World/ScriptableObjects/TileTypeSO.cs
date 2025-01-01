using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewBlockType", menuName = "Cube/BlockType")]
public class TileTypeSO : ScriptableObject
{
    [JsonProperty]
    public string typeName;
    
    [JsonProperty]
    [Tooltip("Sprite for normal state")]
    public Sprite sprite;

    [JsonProperty] 
    [Tooltip("Sprite for other state")]
    public Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();
}