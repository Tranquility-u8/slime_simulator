using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class Item : Entity
{
    [JsonProperty]
    public ItemTypeSO itemType;

    [JsonProperty]
    public ItemState itemState;
    
    public Item(string _name)
    {
        itemType = EntityData.Instance.GetItemTypeByName(_name);
    }
    
    public override void Render(int _renderSize)
    {

        gameObject = new GameObject();
        gameObject.transform.SetParent(EntityData.Instance.transform);
        gameObject.transform.position = new Vector3Int(cube.x * _renderSize, (cube.y + 1) * _renderSize, 0);
        
        sr = gameObject.AddComponent<SpriteRenderer>();
        sr.sprite = itemType.sprite;
        float c = (120 + cube.z * 25)/ 255f;
        sr.color = new Color(c, c, c);
        
        UpdateSpriteSortingOrder();
    }
    
    public bool IsDropped => itemState == ItemState.Dropped;
    
    public bool IsInstalled => itemState == ItemState.Installed;
    
    public bool IsPickedUp => itemState == ItemState.PickedUp;
}

public enum ItemState
{
    Dropped,
    Installed,
    PickedUp,
}