using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class Character : Entity
{
    #region members
    
    [JsonProperty]
    public CharacterTypeSO characterType;
    
    #endregion

    #region methods
    
    public Character(string _name, Zone _zone, int _x, int _y, int _z)
    {
        name = _name;
        location = new Location(_zone, _x, _y, _z);
        characterType = EntityData.Instance.GetCharacterTypeByName(_name);
    }
    
    public override void Advance()
    {
    }
    
    public virtual bool IsPC
    {
        get
        {
            return false;   
        }
    }
    
    #endregion
}
