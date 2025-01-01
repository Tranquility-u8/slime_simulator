using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Zone : Grid3d<Block>
{
    private Dictionary<Vector3Int, Block> blocks;

    public Zone()
    {
        blocks = new Dictionary<Vector3Int, Block>();
    }
    
    public void AddBlock(Block block)
    {
        if (!blocks.ContainsKey(block.GetPosition()))
        {
            blocks.Add(block.GetPosition(), block);
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