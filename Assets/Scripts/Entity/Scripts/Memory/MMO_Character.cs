using UnityEngine;

public class MMO_Character: IMemorable
{
    public Character character;
    
    public Vector3Int posSeen; // Not always true, though

    public int likability;
    
    public bool IsEnemy => likability < 0;
    
    public bool IsFriend => likability > 100;

    public MMO_Character(Character _character, Vector3Int _posSeen, int _likability = 50)
    {
        character = _character;
        posSeen = _posSeen;
        likability = _likability;
    }
}

