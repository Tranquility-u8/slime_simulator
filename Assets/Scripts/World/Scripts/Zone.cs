using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using UnityEngine;

public class Zone : Grid3d<Cube>
{
    #region members

    [JsonProperty]
    public bool hasGravity = false;

    [JsonProperty]
    private List<GridBase> grids;
    
    [JsonProperty]
    public Dictionary<string, Character> charactersDict;
    
    #endregion

    #region methods
    
    public Zone(string _name, int _sizeX = 64, int _sizeY = 64, int _sizeZ = 2)
    {
        name = _name;
        sizeX = _sizeX;
        sizeY = _sizeY;
        sizeZ = _sizeZ;
        
        grid = new Cube[_sizeX, _sizeY, _sizeZ];
        for (int i = 0; i < _sizeX; i++)
        {
            for (int j = 0; j < _sizeY; j++)
            {
                for (int k = 0; k < _sizeZ; k++)
                {
                    grid[i, j, k] = new Cube(i, j, k);
                }
            }
        }
        
        charactersDict = new Dictionary<string, Character>();
    }
    
    public bool TryPlaceItem(Item item, int x, int y, int z)
    {
        if(!IsValidCell(x, y, z)) return false;
        
        Cube c = grid[x, y, z];
        if (c.IsInstalled)
        {
            Debug.Log(name + " Already installed");
            return false;
        }
        c.ItemInstalled = item;
        return true;
    }

    public bool PlaceItem(Item item, int x, int y, int z)
    {
        
        if(!IsValidCell(x, y, z)) return false;
        
        grid[x, y, z].ItemInstalled = item;
        return true;
    }
    
    public override void Render()
    {
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                for (int k = 0; k < sizeZ; k++)
                {
                    Cube cube = grid[i, j, k];
                    cube.Render(renderSize);
                }
                            
            }
        }
        
    }

    public bool AddCharacter(Character _character, int x, int y, int z)
    {
         if(!IsValidCell(x, y, z)) return false;

         if (grid[x, y, z].IsInstalled)
         {
             Debug.LogWarning("Character already installed");
             return false;
         }
        charactersDict[_character.name] = _character;
        grid[x, y, z].Character = _character;
        _character.zone = this;
        _character.cube = grid[x, y, z];
        return true;
    }

    public void removeCharacter(Character _character)
    {
        if(charactersDict.ContainsKey(_character.name))
            charactersDict.Remove(_character.name);
    }

    public bool MoveCharacterTo(Character character, Vector3Int destination)
    {
        if(!IsValidCell(destination)) return false;
        
        Cube origin = character.cube;
        Grid(destination).Character = character;
        origin.Character = null;
        return true;
    }

    public Cube Grid(Vector3Int position)
    {
        return grid[position.x, position.y, position.z];
    }
    #endregion
    
}