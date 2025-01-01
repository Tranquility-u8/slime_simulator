using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Zone : Grid<Block>
{
    private Dictionary<Vector3Int, Block> blocks;

    public Zone()
    {
        blocks = new Dictionary<Vector3Int, Block>();
    }
    
    public void AddBlock(Block block)
    {
        if (!blocks.ContainsKey(block.GetPositionVec3()))
        {
            blocks.Add(block.GetPositionVec3(), block);
        }
    }
    
    public bool RemoveBlock(Vector3Int position)
    {
        return blocks.Remove(position);
    }
    
    public Block GetBlock(Vector3Int position)
    {
        blocks.TryGetValue(position, out Block block);
        return block;
    }
    
    public void Render()
    {
        var orderedBlocks = blocks.Values
            .OrderByDescending(b => b.y)
            .OrderBy(b => b.z);

        foreach (var block in orderedBlocks)
        {
            ///block.Render();
        }
    }
    
}