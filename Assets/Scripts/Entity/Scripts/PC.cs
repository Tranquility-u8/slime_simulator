using System.Collections;
using System.Collections.Generic;
using Modern2D;
using UnityEngine;

public class PC : Character
{
    #region members



    #endregion

    #region methods
    
    public PC()
        : base("Slime")
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