using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PC : Character
{
    #region members



    #endregion

    #region methods
    
    public PC(Zone _zone, int _x, int _y, int _z)
        : base("Player", _zone, _x, _y, _z)
    {
        
    }

    
    public override void Advance()
    {
        
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