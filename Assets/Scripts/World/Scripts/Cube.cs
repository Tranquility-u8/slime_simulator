using System.Collections.Generic;
using UnityEngine;
using Newtonsoft;
using Newtonsoft.Json;

/// <summary>
/// A virtual unit that represents a cubic space
/// </summary>
public class Cube : Cell3d
{
    #region members
    
    [Header("Entity container")]
    [JsonProperty]
    private Item itemInstalled;

    public Item ItemInstalled
    {
        get => itemInstalled;
        set
        {
            itemInstalled = value;
        }
    }
    
    [JsonProperty]
    private List<Item> itemDropped;
    
    [JsonProperty]
    private Character character;
    
    public Character Character
    {
        get;
        set;
    }
    
    [Header("Render")]
    private SpriteRenderer sr;
    
    public GameObject gameObject;
    
    #endregion

    #region methods

    public Cube(int _x, int _y, int _z)
    {
        x = _x;
        y = _y;
        z = _z;
    }
    
    public void BeforeRender(int _renderPx, int _renderPy)
    {
        gameObject = new GameObject();
        gameObject.transform.position = new Vector3Int(_renderPx, _renderPy, 0);
    }

    public void OnRender()
    {
        if(!IsInstalled) return;
        
        sr = gameObject.AddComponent<SpriteRenderer>();
        sr.sprite = itemInstalled.itemType.sprite;
        sr.sortingOrder = y * -1 + z * 1000 - 5000;
        float c = (120 + z * 25)/ 255f;
        sr.color = new Color(c, c, c);
    }

    public void Uninstall()
    {
        itemInstalled = null;
    }
    
    public bool IsInstalled => itemInstalled != null;


    #endregion



}
