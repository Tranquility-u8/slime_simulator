using System.Collections.Generic;
using UnityEngine;


public class BlockManager : Singleton<BlockManager>
{
    #region members
    
    private Dictionary<string, BlockTypeSO> blockTypeDictionary;

    [SerializeField] private BlockTypeSO[] blockTypeDict;
        
    #endregion

    #region methods

    protected override void Awake()
    {
        base.Awake();
        
        this.transform.position = new Vector3(0, 0, 0);
        
        // Init blockTypeDic
        blockTypeDictionary = new Dictionary<string, BlockTypeSO>();
        foreach (var blockType in blockTypeDict)
        {
            if (!blockTypeDictionary.ContainsKey(blockType.typeName))
            {
                blockTypeDictionary.Add(blockType.typeName, blockType);
            }
        }
    }
    
    public BlockTypeSO GetBlockTypeByName(string _name)
    {
        if (blockTypeDictionary.TryGetValue(name, out var blockTypeData))
        {
            return blockTypeData;
        }
        Debug.LogError($"BlockTypeSO with name {name} not found!");
        return null;
    }

    #endregion
    

}