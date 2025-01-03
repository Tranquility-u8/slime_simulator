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
        
    public static void MoveRandom (this Character character)
    {
        int dir = Random.Range(0, 3);
        character.gameObject.transform.Translate(DirectionVec3[dir]);
        character.UpdateSortingOrder();
    }

    public static void MoveTowards(this Character character, int direction)
    {
        character.gameObject.transform.Translate(DirectionVec3[direction % 4]);
        character.UpdateSortingOrder();
    }
    
    public static void MoveLeft(this Character character)
    {
        character.gameObject.transform.Translate(Vector3.left);
        character.UpdateSortingOrder();
    }
    
    public static void MoveRight(this Character character)
    {
        character.gameObject.transform.Translate(Vector3.right);
        character.UpdateSortingOrder();
    }
    
    public static void MoveUp(this Character character)
    {
        character.gameObject.transform.Translate(Vector3.up);
        character.UpdateSortingOrder();
    }
    
    public static void MoveDown(this Character character)
    {
        character.gameObject.transform.Translate(Vector3.down);
        character.UpdateSortingOrder();
    }
}
