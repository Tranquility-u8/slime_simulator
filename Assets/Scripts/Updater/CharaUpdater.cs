using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaUpdater : BaseUpdater
{
    private readonly Character pc;

    public CharaUpdater(Character _pc)
    {
        pc = _pc;
    }
    
    public override void FixedUpdate()
    {
        foreach (var term in Core.Instance.currentZone.charactersDict)
        {
            Character character = term.Value;
            if (!character.IsPC)
            {
                character.Update();
            }
        }
    }

    public void UpdateCharasActionTimer(int actionPoint = 1)
    {
        foreach (var term in Core.Instance.currentZone.charactersDict)
        {
            Debug.Log(term.Value.name);
            Character character = term.Value;
            if (!character.IsPC)
            {
                character.actionTimer += actionPoint * 100f / pc.Speed;
            }
        }
    }
}
