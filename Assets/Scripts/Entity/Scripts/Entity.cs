using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class Entity
{
    #region members
    
    [JsonProperty]
    public int id;
    
    [JsonProperty]
    public string name;

    [Header("Position")] 
    
    [ES3NonSerializable]
    public Zone zone;
    
    [ES3NonSerializable]
    public Cube cube;
    
    public Vector3Int Position => new Vector3Int(cube.x, cube.y, cube.z);
    
    [ES3NonSerializable]
    public bool IsOnZone => zone != null;
    
    [Header("Generated while gaming")]
    [ES3NonSerializable]
    public GameObject gameObject;
    
    [ES3NonSerializable]
    public SpriteRenderer sr;
    
    #endregion
    
    #region methods
    
    public virtual void Update()
    {
    }

    public virtual void Advance()
    {
        
    }

    public virtual void Render(int _renderSize)
    {
        
    } 
    
    public virtual void UpdateSprite(int _renderSize = 1)
    {
        UpdateSpritePosition(_renderSize);
        UpdateSpriteSortingOrder();
    }
    
    protected virtual void UpdateSpritePosition(int _renderSize)
    {
        gameObject.transform.position = new Vector3((float)cube.x + (float)_renderSize * 0.5f , cube.y + (float)_renderSize * 0.5f, 0);
    }
    
    protected virtual void UpdateSpriteSortingOrder()
    {
        sr.sortingOrder = cube.y * -1 + cube.z * 1000 - 5000;
    }
    
    #endregion
}
