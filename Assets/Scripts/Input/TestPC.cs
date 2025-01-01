using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPC : Singleton<TestPC>
{
    private Character pc;
    private Transform trans;

    public void AssignPC()
    {
        pc = Core.Instance.game.activePC;
        trans = pc.gameObject.transform;
    }
    
    
    void Update()
    {
        switch (SSInput.action)
        {
            case SSAction.AxisLeft:
                ActionHelper.MoveLeft(pc);
                Core.Instance.game.gameUpdater.charaUpdater.UpdateActionTimer();
                break;
            case SSAction.AxisRight:
                ActionHelper.MoveRight(pc);
                Core.Instance.game.gameUpdater.charaUpdater.UpdateActionTimer();
                break;
            case SSAction.AxisUp:
                ActionHelper.MoveUp(pc);
                Core.Instance.game.gameUpdater.charaUpdater.UpdateActionTimer();
                break;
            case SSAction.AxisDown:
                ActionHelper.MoveDown(pc);
                Core.Instance.game.gameUpdater.charaUpdater.UpdateActionTimer();
                break;
        }
        
    }
}
