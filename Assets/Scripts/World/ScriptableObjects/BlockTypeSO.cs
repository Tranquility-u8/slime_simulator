using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewBlockType", menuName = "Block/BlockType")]
public class BlockTypeSO : ScriptableObject
{
    #region members
    
    [JsonProperty]
    public string typeName;
    
    [JsonProperty]
    [Tooltip("Sprite for normal state")]
    public Sprite sprite;

    [JsonProperty] 
    [Tooltip("Sprite for other state")]
    public Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();
    
    #endregion
    
    #region methods

    public Sprite GetSprite(string _name)  
    {  
        if (sprites.TryGetValue(_name, out Sprite sprite1))  
        {  
            return sprite1;  
        }  
    
        Debug.LogWarning("Sprite not found: " + _name);  
        return null;  
    }
        
    #endregion    
}