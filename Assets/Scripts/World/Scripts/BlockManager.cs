using System.Collections.Generic;
using UnityEngine;


public class BlockManager : Singleton<BlockManager>
{
    
    private Dictionary<string, BlockTypeSO> blockTypeDictionary;

    [SerializeField]
    private BlockTypeSO[] blockTypes;

    protected override void Awake()
    {
        base.Awake();
        this.transform.position = new Vector3(0, 0, 0);
        
        blockTypeDictionary = new Dictionary<string, BlockTypeSO>();
        foreach (var blockType in blockTypes)
        {
            if (!blockTypeDictionary.ContainsKey(blockType.typeName))
            {
                blockTypeDictionary.Add(blockType.typeName, blockType);
            }
        }
    }
    
    public BlockTypeSO GetBlockTypeDataByName(string name)
    {
        if (blockTypeDictionary.TryGetValue(name, out var blockTypeData))
        {
            return blockTypeData;
        }
        else
        {
            Debug.LogError($"BlockTypeSO with name {name} not found!");
            return null;
        }
    }
}