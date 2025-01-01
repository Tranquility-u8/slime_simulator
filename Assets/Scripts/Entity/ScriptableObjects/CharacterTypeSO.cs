using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewCharacterType", menuName = "Entity/CharacterType")]
public class CharacterTypeSO : ScriptableObject
{
    #region members
    
    [JsonProperty]
    public string typeName;
    
    [JsonProperty]
    [Tooltip("Sprite for normal state")]
    public Sprite sprite;

    [JsonProperty] 
    [Tooltip("Sprite for other state")]
    public List<SpriteDictionaryEntry> spriteEntries = new List<SpriteDictionaryEntry>(); 
    
    #endregion
    
    #region methods

    public Sprite GetSprite(string _name)  
    {
        foreach (SpriteDictionaryEntry entry in spriteEntries)
        {
            if(entry.stateName == _name)
                return entry.sprite;
        }
        
        Debug.LogWarning("Sprite not found: " + _name);  
        return null;  
    }
        
    #endregion    
}
