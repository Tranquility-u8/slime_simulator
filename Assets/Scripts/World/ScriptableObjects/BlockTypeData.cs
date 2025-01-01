using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewBlockType", menuName = "Block/BlockType")]
public class BlockTypeData : ScriptableObject
{
    public string typeName;
    public Sprite sprite;

}