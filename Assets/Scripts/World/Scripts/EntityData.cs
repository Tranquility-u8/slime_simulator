using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class EntityData : Singleton<EntityData>
{
    #region members
    
    private Dictionary<string, ItemTypeSO> itemTypeDict;

    [SerializeField] private ItemTypeSO[] itemTypes;
        
    private Dictionary<string, CharacterTypeSO> characterTypeDict;

    [SerializeField] private CharacterTypeSO[] characterTypes;
    
    #endregion

    #region methods

    protected override void Awake()
    {
        base.Awake();
        
        this.transform.position = new Vector3(0, 0, 0);
        
        // Init itemTypeDict
        itemTypeDict = new Dictionary<string, ItemTypeSO>();
        foreach (var itemType in itemTypes)
        {
            if (!itemTypeDict.ContainsKey(itemType.typeName))
            {
                itemTypeDict.Add(itemType.typeName, itemType);
            }
        }
        // Init characterTypeDict
        characterTypeDict = new Dictionary<string, CharacterTypeSO>();
        foreach (var characterType in characterTypes)
        {
            if (!itemTypeDict.ContainsKey(characterType.typeName))
            {
                characterTypeDict.Add(characterType.typeName, characterType);
            }
        }
    }
    
    public ItemTypeSO GetItemTypeByName(string _name)
    {
        if (itemTypeDict.TryGetValue(_name, out var itemTypeData))
        {
            return itemTypeData;
        }
        Debug.LogError($"ItemTypeSO with name {name} not found!");
        return null;
    }

    public CharacterTypeSO GetCharacterTypeByName(string _name)
    {
        if (characterTypeDict.TryGetValue(_name, out var characterTypeData))
        {
            return characterTypeData;
        }
        Debug.LogError($"CharacterTypeSO with name {_name} not found!");
        return null;
    }
    
    #endregion
    

}