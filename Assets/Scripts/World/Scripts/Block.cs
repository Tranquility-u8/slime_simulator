using UnityEngine;
using Newtonsoft;
using Newtonsoft.Json;


public class Block : Cell3d
{
    #region members
    
    [JsonProperty]
    public BlockTypeSO blockType;

    [JsonProperty]
    public Direction direction;
    
    [JsonProperty]
    public BlockState state;
    
    private SpriteRenderer sr;
    
    public GameObject gameObject;
    
    #endregion

    #region methods

    public Block(BlockTypeSO _blockType, int _x, int _y, int _z,  Direction _direction = Direction.North, BlockState _state = BlockState.Normal)
    {
        blockType = _blockType;
        x = _x;
        y = _y;
        z = _z;
        direction = _direction;
        state = _state;
    }
    
    public Block(string _typename, int _x, int _y, int _z,  Direction _direction = Direction.North, BlockState _state = BlockState.Normal)
    {
        blockType = BlockManager.Instance.GetBlockTypeByName(_typename);
        x = _x;
        y = _y;
        z = _z;
        direction = _direction;
        state = _state;
    }

    public void BeforeRender(int _renderX, int _renderY)
    {
        gameObject.transform.position = new Vector3Int(_renderX, _renderY, 0);
    }

    public void OnRender()
    {
        sr = gameObject.AddComponent<SpriteRenderer>();
    }
    
    #endregion
    
    public enum BlockState
    {
        Normal = 0,
    }
    
}
