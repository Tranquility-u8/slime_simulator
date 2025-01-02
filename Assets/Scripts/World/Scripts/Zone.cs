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
    
    public void TryPlaceItem(Item _item)
    {
        int x = _item.location.x;
        int y = _item.location.y;
        int z = _item.location.z;
        
        if(!IsValidBlock(x, y, z)) return;
        
        Cube c = grid[x, y, z];
        if(!c.IsInstalled)
            c.ItemInstalled = _item;
    }

    public void PlaceItem(Item _item)
    {
        
        int x = _item.location.x;
        int y = _item.location.y;
        int z = _item.location.z;
        
        if(!IsValidBlock(x, y, z)) return;
        
        grid[x, y, z].ItemInstalled = _item;
    }
    
    
    public void RemoveBlock(int _x, int _y, int _z)
    {
        if(!IsValidBlock(_x, _y, _z)) return;
        
        grid[_x, _y, _z].Uninstall();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]  
    private bool IsValidBlock(int x, int y, int z)
    {
        return x >= 0 && x < sizeX && y >= 0 && y < sizeY && z >= 0 && z < sizeZ;
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


    
    public void AddCharacter(Character _character)
    {
        charactersDict[_character.name] = _character;
        Location location = _character.location;
        grid[location.x, location.y, location.z].Character = _character;
    }

    public void removeCharacter(Character _character)
    {
        if(charactersDict.ContainsKey(_character.name))
            charactersDict.Remove(_character.name);
    }
    
    #endregion
    
}