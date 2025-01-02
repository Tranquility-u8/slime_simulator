using UnityEngine;

public class ActionHelper
{
    public static readonly Vector3[] directionVec3 = new Vector3[]
    {
        new Vector3(0, 1, 0),
        new Vector3(1, 0, 0),
        new Vector3(0, -1, 0),
        new Vector3(-1, 0, 0),
    };
        
    public static void MoveRandom (Character character)
    {
        character.gameObject.transform.Translate(directionVec3[Random.Range(0, 3)]);
    }

    public static void MoveLeft(Character character)
    {
        character.gameObject.transform.Translate(Vector3.left);
    }
    
    public static void MoveRight(Character character)
    {
        character.gameObject.transform.Translate(Vector3.right);
    }
    
    public static void MoveUp(Character character)
    {
        character.gameObject.transform.Translate(Vector3.up);
    }
    
    public static void MoveDown(Character character)
    {
        character.gameObject.transform.Translate(Vector3.down);
    }
}