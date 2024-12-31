using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "NewBlockType", menuName = "Block/BlockType")]
public class BlockTypeData : ScriptableObject
{
    public string typeName; // 可以用字符串描述BlockType
    public Sprite sprite;

}