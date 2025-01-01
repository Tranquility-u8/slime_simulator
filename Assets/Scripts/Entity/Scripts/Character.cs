using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class Character : Entity
{
    #region members
    
    public GameObject gameObject;
    
    [JsonProperty]
    public CharacterTypeSO characterType;
    
    [JsonProperty]
    private float speed;

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
            actionMaxTime = 100f / speed;
        }
    }
    
    public float actionTimer;
    
    public float actionMaxTime;
    
    public int actionPoint;
    
    #endregion

    #region methods
    
    public Character(string _name, Zone _zone, int _x, int _y, int _z)
    {
        name = _name;
        location = new Location(_zone, _x, _y, _z);
        characterType = EntityData.Instance.GetCharacterTypeByName(_name);
        speed = 100f;
        actionTimer = 0f;
        actionMaxTime = 100f / speed;
        actionPoint = 0;
    }
    
    public override void Update()
    {
        if (actionTimer >= actionMaxTime)
        {
            int gainActionPoint = (int)(actionTimer * 10) / (int)(actionMaxTime * 10);
            actionPoint += gainActionPoint;
            actionTimer -= gainActionPoint * actionMaxTime;
            actionTimer = Mathf.Max(actionTimer, 0);
        }
    }
    
    public override void Advance()
    {
        if(actionPoint <= 0) return;
        for (int i = 0; i < actionPoint; i++)
        {
            Debug.Log("Advance: " + name);
            ActionHelper.MoveRandom(this);
        }

        actionPoint = 0;
    }
    
    public override void Render(int _renderSize)
    {
        gameObject = EntityData.Instantiate(characterType.prefab);
        gameObject.transform.position = new Vector3((float)location.x + (float)_renderSize * 0.5f , location.y + (float)_renderSize * 0.5f, 0);
    } 
    
    public virtual bool IsPC
    {
        get
        {
            return false;   
        }
    }
    
    #endregion
}
