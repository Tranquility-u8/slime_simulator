using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using UnityEngine;

public class Zone : Grid3d<Block>
{
    #region members
    
    [JsonProperty]
    private BlockContainer[ , , ] blockContainers;
    
    private List<GridBase> grids;
    
    #endregion

    #region methods
    
    public Zone(string _name, int _sizeX = 100, int _sizeY = 100, int _sizeZ = 5)
    {
        name = _name;
        sizeX = _sizeX;
        sizeY = _sizeY;
        sizeZ = _sizeZ;
        
        blockContainers = new BlockContainer[_sizeX, _sizeY, _sizeZ];
        for (int i = 0; i < _sizeX; i++)
        {
            for (int j = 0; j < _sizeY; j++)
            {
                for (int k = 0; k < _sizeZ; k++)
                {
                    blockContainers[i, j, k] = new BlockContainer(null);
                }
            }
        }
    }
    
    public void TryPlaceBlock(Block _block)
    {
        int _x = _block.x;
        int _y = _block.y;
        int _z = _block.z;
        
        if(!IsValidBlock(_x, _y, _z)) return;
        
        BlockContainer bc = blockContainers[_x, _y, _z];
        if(bc.IsEmpty)
            bc.Block = _block;
    }

    public void PlaceBlock(Block _block)
    {
        int _x = _block.x;
        int _y = _block.y;
        int _z = _block.z;
        
        if(!IsValidBlock(_x, _y, _z)) return;

        BlockContainer bc = blockContainers[_x, _y, _z];
        bc.Block = _block;
    }
    
    
    public void RemoveBlock(int _x, int _y, int _z)
    {
        if(!IsValidBlock(_x, _y, _z)) return;
        
        blockContainers[_x, _y, _z].Reset();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]  
    private bool IsValidBlock(int x, int y, int z)
    {
        return x >= 0 && x < sizeX && y >= 0 && y < sizeY && z >= 0 && z < sizeZ;
    }
    
    public Block GetBlock(int _x, int _y, int _z)
    {
        if(!IsValidBlock(_x, _y, _z)) return null;
        
        return blockContainers[_x, _y, _z].Block;
    }
    
    public override void Render()
    {
        base.Render();
        
        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                for (int k = 0; k < sizeZ; k++)
                {
                    BlockContainer bc = blockContainers[i, j, k];
                    RenderBlock(bc.Block);
                }
                            
            }
        }
        
    }

    private void RenderBlock(Block _block)
    {
        if(_block == null) return;
        _block.BeforeRender(_block.x * renderSize, _block.y * renderSize);
        _block.OnRender();
    }

    #endregion

    private class BlockContainer
    {
        private Block block;

        public Block Block { get; set; }

        public bool IsEmpty => block == null;
        
        public void Reset()
        {
            block = null;
        }
        
        public BlockContainer(Block block)
        {
            this.block = block;
        }
    }
}