using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class Item : Entity
{
    [JsonProperty]
    public ItemTypeSO itemType;

    [JsonProperty]
    public Direction direction;

    public Item(string _name, Zone _zone, int _x, int _y, int _z)
    {
        location = new Location(_zone, _x, _y, _z);
        itemType = EntityData.Instance.GetItemTypeByName(_name);
    }
    
    public override void Update()
    {
    }
}