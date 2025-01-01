using System.Collections.Generic;
using UnityEngine;


public class BlockManager : Singleton<BlockManager>
{
    
    private Dictionary<string, BlockTypeData> blockTypeDictionary;

    [SerializeField]
    private BlockTypeData[] blockTypes;

    protected override void Awake()
    {
        base.Awake();
        this.transform.position = new Vector3(0, 0, 0);
        
        blockTypeDictionary = new Dictionary<string, BlockTypeData>();
        foreach (var blockType in blockTypes)
        {
            if (!blockTypeDictionary.ContainsKey(blockType.typeName))
            {
                blockTypeDictionary.Add(blockType.typeName, blockType);
            }
        }
    }
    
    public BlockTypeData GetBlockTypeDataByName(string name)
    {
        if (blockTypeDictionary.TryGetValue(name, out var blockTypeData))
        {
            return blockTypeData;
        }
        else
        {
            Debug.LogError($"BlockTypeData with name {name} not found!");
            return null;
        }
    }
}