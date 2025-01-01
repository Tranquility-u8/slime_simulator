using System.Collections;
using System.Collections.Generic;
using Modern2D;
using UnityEngine;

public class PC : Character
{
    #region members



    #endregion

    #region methods
    
    public PC(Zone _zone, int _x, int _y, int _z)
        : base("Slime", _zone, _x, _y, _z)
    {
        
    }

    
    public override void Update()
    {
        
    }
    
    public override void Render(int _renderSize)
    {
        base.Render(_renderSize);
        SmoothFollow.Instance.SetFollowTarget(gameObject.transform);
    } 
    
    public override bool IsPC
    {
        get
        {
            return true;   
        }
        
    }
    #endregion
}