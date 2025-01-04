using System;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

/// <summary>
/// AI(includes actionMode, memories etc) and circumstance
/// determines SSWill; SSWill eludes to certain SSAction 
/// </summary>
public class AIBase
{
    public Character owner;

    protected Character attackTarget;
    
    [JsonProperty] protected Dictionary<string, MemoryShort<MMO_Character>> ms_characters
        = new Dictionary<string, MemoryShort<MMO_Character>>();

    public SSAction action;
    
    public SSWill will;
    
    public AIBase()
    {
        action = SSAction.None;
        will = SSWill.Roam;
    }

    public void Execute()
    {
        UpdateMemoryBefore();
        UpdateCurrentWill();
        OnAction();
        UpdateMemoryAfter();
    }

    protected virtual void UpdateMemoryBefore()
    {
        return;
    }
    
    protected virtual void UpdateCurrentWill()
    {
        will = SSWill.Roam;
        attackTarget = null;
        foreach (var ms in ms_characters.Values)
        {
            if (ms.value.IsEnemy)
            {
                will = SSWill.Attack;
                attackTarget = ms.value.character;
                return;
            }
        }
   
    }
    
    protected virtual void UpdateMemoryAfter()
    {
        return;
    }
    
    protected virtual void OnAction()
    {
        if (will == SSWill.Roam)
        {
            ActionHelper.MoveRandom(owner);
            Debug.Log(owner.name + " is Roaming");
            return;
        }

        if (will == SSWill.Attack)
        {
            ActionHelper.MoveTowardsTarget(owner, attackTarget);
            Debug.Log(owner.name + " is Attacking");
            return;
        }
    }
    
}

