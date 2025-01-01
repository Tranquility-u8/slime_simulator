using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaUpdater : BaseUpdater
{
    public override void FixedUpdate()
    {
        foreach (var term in Core.Instance.currentZone.charactersDict)
        {
            Character character = term.Value;
            if (!character.IsPC)
            {
                character.Update();
                character.Advance();
            }
        }
    }

    public void UpdateActionTimer()
    {
        Character pc = Core.Instance.game.activePC;
        foreach (var term in Core.Instance.currentZone.charactersDict)
        {
            Character character = term.Value;
            
            if (!character.IsPC)
            {
                character.actionTimer += 100f / pc.Speed;
            }
        }
    }
}
