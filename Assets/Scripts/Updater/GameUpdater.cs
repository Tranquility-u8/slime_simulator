using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUpdater
{
    #region members

    private Character pc;
    
    private ZoneUpdater zoneUpdater;
    private LogicUpdater logicUpdater;
    private CharaUpdater charaUpdater;
    
    #endregion

    public GameUpdater(Character _pc)
    {
        if (_pc == null)
        {
            Debug.LogError("Null pc");
        }
        pc = _pc;
        
        zoneUpdater = new ZoneUpdater();
        logicUpdater = new LogicUpdater();
        charaUpdater = new CharaUpdater(pc);
    }
    
    public void FixedUpdate(int actionPoint = 1)
    {
        charaUpdater.UpdateCharasActionTimer(actionPoint);
        
        if (Core.Instance.isPaused)
        {
            return;
        }
        
        zoneUpdater.FixedUpdate();
        logicUpdater.FixedUpdate();
        charaUpdater.FixedUpdate();
    }
    
}
