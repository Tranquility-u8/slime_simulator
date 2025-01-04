using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class Character : Entity
{
    #region members
    
    protected AIBase ai;

    [ES3NonSerializable]
    public AIBase AI
    {
        set
        {
            value.owner = this;
            ai = value;
        }
    }
    
    public CharacterTypeSO characterType;
    
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
    
    public Character()
    {
        this.AI = new AIBase();
    }
    
    
    public Character(string _name)
    {
        this.AI = new AIBase();
        name = _name;
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
        Advance();
    }
    
    public override void Advance()
    {
        if(actionPoint <= 0) return;
        for (int i = 0; i < actionPoint; i++)
        {
            ai.Execute();
        }
        actionPoint = 0;
    }
    
    public override void Render(int _renderSize)
    {
        if(gameObject != null) return;
        gameObject = EntityData.Instantiate(characterType.prefab);

        sr = gameObject.GetComponent<SpriteRenderer>();
        shadowSr = gameObject.transform.Find("shadowPivot").Find("shadow").GetComponent<SpriteRenderer>();   // Bad code
        
        UpdateSprite(_renderSize);
        gameObject.SetActive(false);  
        gameObject.SetActive(true);  
    }
    
    protected override void UpdateSpriteSortingOrder()
    {
        sr.sortingOrder = cube.y * -1 + cube.z * 1000 - 5000;
        shadowSr.sortingOrder = cube.y * -1 + cube.z * 1000 - 5050;
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
