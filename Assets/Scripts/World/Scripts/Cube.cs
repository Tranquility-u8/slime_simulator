using System.Collections.Generic;
using UnityEngine;
using Newtonsoft;
using Newtonsoft.Json;
using NUnit.Framework;

/// <summary>
/// A virtual unit that represents a cubic space
/// </summary>
public class Cube : Cell3d
{
    #region members
    
    [JsonProperty]
    private Item itemInstalled;
    
    [JsonProperty]
    private List<Item> itemDropped;
    
    [JsonProperty]
    private Character character;
    
    #endregion

    #region methods

    public Cube(int _x, int _y, int _z)
    {
        x = _x;
        y = _y;
        z = _z;
        
        itemDropped = new List<Item>();
    }

    public void Render(int renderSize)
    {
        RenderInstalledItem(renderSize);
        RenderCharacter(renderSize);
    }
    
    public void RenderInstalledItem(int renderSize)
    {
        if(!this.IsInstalled) return;
        this.ItemInstalled.Render(renderSize);
    }

    public void RenderCharacter(int renderSize)
    {
        if(!this.IsOccupied) return;
        
        Character character = this.Character;
        if(character == null) return;
        character.Render(renderSize);
    }
    
    public override bool IsEmpty()
    {
        return !IsInstalled;
    }

    public bool IsInstalled => itemInstalled != null;

    public Item ItemInstalled
    {
        get => itemInstalled;
        set
        {
            value.cube = this;
            value.itemState = ItemState.Installed;
            itemInstalled = value;
        }
    }
    
    public Character Character
    {
        get => character;
        set
        {
            character = value;
            if (value != null)
                value.cube = this;
        }
    }

    public bool IsOccupied => character != null;
    
    #endregion



}
