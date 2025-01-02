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
    
    public Item(string _name, Zone _zone, int _x, int _y, int _z)
    {
        location = new Location(_zone, _x, _y, _z);
        itemType = EntityData.Instance.GetItemTypeByName(_name);
    }
    
    public override void Render(int _renderSize)
    {

        gameObject = new GameObject();
        gameObject.transform.SetParent(EntityData.Instance.transform);
        gameObject.transform.position = new Vector3Int(location.x * _renderSize, (location.y + 1) * _renderSize, 0);
        
        sr = gameObject.AddComponent<SpriteRenderer>();
        sr.sprite = itemType.sprite;
        float c = (120 + location.z * 25)/ 255f;
        sr.color = new Color(c, c, c);
        
        UpdateSortingOrder();
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