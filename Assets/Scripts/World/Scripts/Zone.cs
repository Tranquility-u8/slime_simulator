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
    
    public Zone(int _sizeX = 100, int _sizeY = 100, int _sizeZ = 5)
    {
        sizeX = _sizeX;
        sizeY = _sizeY;
        sizeZ = _sizeZ;
        
        blockContainers = new BlockContainer[_sizeX, _sizeY, _sizeZ];
    }
    
    public void TryPlaceBlock(Block _block, int _x, int _y, int _z)
    {
        if(!IsValidBlock(_x, _y, _z)) return;
        
        BlockContainer bc = blockContainers[_x, _y, _z];
        if(!bc.isOccupied)
            bc.Block = _block;
    }

    public void PlaceBlock(Block _block, int _x, int _y, int _z)
    {
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

    private struct BlockContainer
    {
        public bool isOccupied;
        private Block block;

        public Block Block
        {
            set
            {
                block = value; 
                isOccupied = true;
            }
            get
            {
                if(!isOccupied) return null;
                return block;
            }
        }

        public void Reset()
        {
            isOccupied = false;
            block = null;
            // Remember to GC
        }
        
        public BlockContainer(Block block)
        {
            isOccupied = true;
            this.block = block;
        }
    }
}