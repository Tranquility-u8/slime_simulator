using UnityEngine;

public class Block
{
    #region members
    
    public GameObject gameObject;
    
    public Vector3Int pos { get; private set; }
    public BlockTypeData blockTypeData { get; private set; }
    
    public int orientation { get; private set; } 

    #endregion


    public Block(Vector3Int _pos, string blockName, int _orientation)
    {
        BlockTypeData _blockTypeData = BlockManager.Instance.GetBlockTypeDataByName(blockName);
        if (_blockTypeData != null)
        {
            pos = _pos;
            blockTypeData = _blockTypeData;
            orientation = _orientation;
        }
    }

    public void Render()
    {
        gameObject = new GameObject();
        
        gameObject.transform.SetParent(BlockManager.Instance.transform);
        
        Vector3 renderPos = new Vector3(pos.x, pos.y + 0.5f * pos.z, 0);
        gameObject.transform.position = renderPos;
        
        SpriteRenderer sr = gameObject.AddComponent<SpriteRenderer>();
        sr.sprite = blockTypeData.sprite;
        sr.color = new Color(88f / 255, 118f / 255, 112f / 255);
        sr.sortingOrder = pos.y * -1000 + pos.z; 
    }
    
}