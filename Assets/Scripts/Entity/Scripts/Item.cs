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
    
    public Item()
    {
    }
    
    public Item(string _name)
    {
        itemType = EntityData.Instance.GetItemTypeByName(_name);
    }
    
    public override void Render(int _renderSize)
    {
        if(gameObject != null) return;
        gameObject = EntityData.Instantiate(itemType.prefab);
        
        float c = (120 + cube.z * 25)/ 255f;
        sr = gameObject.GetComponent<SpriteRenderer>();
        sr.color = new Color(c, c, c);
        
        if(itemType.CanCastShadow)
            shadowSr = gameObject.transform.Find("shadowPivot").Find("shadow").GetComponent<SpriteRenderer>();   // Bad code    
        
        UpdateSprite(_renderSize);
    }
    
    protected override void UpdateSpritePosition(int _renderSize)
    {
        Transform t = gameObject.transform;
        t.position = new Vector3(t.position.x + cube.x * _renderSize, t.position.y + (cube.y + 1) * _renderSize, 0);
        t.SetParent(EntityData.Instance.transform);
    }
    
    protected override void UpdateSpriteSortingOrder()
    {
        sr.sortingOrder = cube.y * -1 + cube.z * 1000 - 5000;
        if(itemType.CanCastShadow)
            shadowSr.sortingOrder = cube.y * -1 + cube.z * 1000 - 5050;
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