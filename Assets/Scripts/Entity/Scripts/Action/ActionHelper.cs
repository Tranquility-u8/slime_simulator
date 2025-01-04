using UnityEngine;

public static class ActionHelper
{
    public static readonly Vector3Int[] DirectionVec3 = new Vector3Int[] 
    {
        new Vector3Int(0, 1, 0),
        new Vector3Int(1, 0, 0),
        new Vector3Int(0, -1, 0),
        new Vector3Int(-1, 0, 0),
    };  // Clockwise from north
        
    public static void MoveRandom(this Character character)
    {
        int dir = Random.Range(0, 3);
        Vector3Int vec = DirectionVec3[dir];
        //character.gameObject.transform.Translate(DirectionVec3[dir]);
        character.zone.MoveCharacterTo(character, character.cube.GetPosition() + vec);
        character.UpdateSprite();
    }

    public static void MoveTowards(this Character character, int direction)
    {
        character.zone.MoveCharacterTo(character, character.cube.GetPosition() + DirectionVec3[direction % 4]);
        character.UpdateSprite();
    }
    
    public static void MoveTowardsTarget(this Character character, Character target)
    {
        int dx = target.cube.x - character.cube.x;
        int dy = target.cube.y - character.cube.y;

        if (Mathf.Abs(dx) > Mathf.Abs(dy))
        {
            if (dx > 0)
            {
                MoveRight(character);
            }
            else
            {
                MoveLeft(character);
            }
        }
        else
        {
            if (dy > 0)
            {
                MoveUp(character);
            }
            else
            {
                MoveDown(character);
            }
        }
    }
    
    public static void MoveLeft(this Character character)
    {
        character.zone.MoveCharacterTo(character, character.cube.GetPosition() + Vector3Int.left);
        character.UpdateSprite();
    }
    
    public static void MoveRight(this Character character)
    {
        character.zone.MoveCharacterTo(character, character.cube.GetPosition() + Vector3Int.right);
        character.UpdateSprite();
    }
    
    public static void MoveUp(this Character character)
    {
        character.zone.MoveCharacterTo(character, character.cube.GetPosition() + Vector3Int.up);
        character.UpdateSprite();
    }
    
    public static void MoveDown(this Character character)
    {
        character.zone.MoveCharacterTo(character, character.cube.GetPosition() + Vector3Int.down);
        character.UpdateSprite();
    }
}
