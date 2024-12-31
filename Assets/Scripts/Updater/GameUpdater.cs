using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUpdater
{
    #region members
    public ZoneUpdater zoneUpdater;
    public LogicUpdater logicUpdater;
    public CharaUpdater charaUpdater;
    
    public static float delta;
    
    #endregion
    
    public void Reset()
    {
        zoneUpdater = new ZoneUpdater();
        logicUpdater = new LogicUpdater();
        charaUpdater = new CharaUpdater();
    }

    public void FixedUpdate()
    {
        if (Core.Instance.isPaused)
        {
            return;
        }
        zoneUpdater.FixedUpdate();
        logicUpdater.FixedUpdate();
        charaUpdater.FixedUpdate();
    }
}
