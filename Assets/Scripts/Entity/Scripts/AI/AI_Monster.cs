using UnityEngine;

public class AI_Monster : AIBase
{
    public AI_Monster()
    {
   
    }
    
    protected override void UpdateMemoryBefore()
    {
        foreach (var term in owner.zone.charactersDict)
        {
            Character target = term.Value;
            if(target == owner) continue;
            
            float dist = Vector3Int.Distance(owner.Position, target.Position);
            if (ms_characters.ContainsKey(term.Key))
            {
             
                if(dist > 8)
                    ms_characters.Remove(term.Key);
                return;
            }
            
            if(dist < 3)
                ms_characters[term.Key] = new MemoryShort<MMO_Character>(new MMO_Character(target, target.Position, -1));
        }
        return;
    }
}