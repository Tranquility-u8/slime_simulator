using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class BlockManager : Singleton<BlockManager>
{
    #region members
    
    private Dictionary<string, BlockTypeSO> blockTypeDict;

    [SerializeField] private BlockTypeSO[] blockTypes;
        
    #endregion

    #region methods

    protected override void Awake()
    {
        base.Awake();
        
        this.transform.position = new Vector3(0, 0, 0);
        
        // Init blockTypeDict
        blockTypeDict = new Dictionary<string, BlockTypeSO>();
        foreach (var blockType in blockTypes)
        {
            if (!blockTypeDict.ContainsKey(blockType.typeName))
            {
                blockTypeDict.Add(blockType.typeName, blockType);
            }
        }
    }
    
    public BlockTypeSO GetBlockTypeByName(string _name)
    {
        if (blockTypeDict.TryGetValue(_name, out var blockTypeData))
        {
            return blockTypeData;
        }
        Debug.LogError($"BlockTypeSO with name {name} not found!");
        return null;
    }

    #endregion
    

}