using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class ChunkData
{
    // chunk data for json
    public Chunk.ChunkType type;
    public float height = 20;
    public int minLevel;
    public int maxLevel = 20;
    public int hardLevel = 0;
    public List<ObjectData> objects = new List<ObjectData>();
}
[System.Serializable]
public class ObjectData
{
    public Vector2 pos;
    public float angle;
    public string object_tag;
    public string otherData_json;
}
namespace Data
{

}
