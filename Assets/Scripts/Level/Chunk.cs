using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
public class Chunk : MonoBehaviour
{
    public enum ChunkType
    {
        starter, normal, endLevel, gift
    }
    public ChunkType type;
    public float height = 20;
    public int minLevel;
    public int maxLevel = 20;
    [Header("hard level 0-10")]
    [Range(0,10)] public int hardLevel = 0;

    internal List<ChunkObject> objects
    {
        get
        {
            var v = new List<ChunkObject>();
            for (int i = 0; i < transform.childCount; i++)
            {
                Transform child = transform.GetChild(i);
                if (child.GetComponent<ChunkObject>())
                {
                    v.Add(child.GetComponent<ChunkObject>());
                }
            }
            return v;
        }
    }

    public void GenerateChunk(ChunkData chunkData, ObjectList objectList)
    {
        type = chunkData.type;
        height = chunkData.height;
        minLevel = chunkData.minLevel;
        maxLevel = chunkData.maxLevel;
        hardLevel = chunkData.hardLevel;

        for (int i = 0; i < chunkData.objects.Count; i++)
        {
            var objectData = chunkData.objects[i];
            ChunkObject obj = objectList.GetObject(objectData.object_tag);
            Vector3 position = transform.position + (Vector3)objectData.pos;
            Quaternion rotation = Quaternion.Euler(0, 0, objectData.angle);
            ChunkObject newObject = Instantiate(obj, position, rotation,transform);
            newObject.object_tag = objectData.object_tag;
            newObject.otherData = objectData.otherData_json;
        }
    }
    public ChunkData GetData()
    {
        var data = new ChunkData();
        data.type = type;
        data.height = height;
        data.minLevel = minLevel;
        data.maxLevel = maxLevel;
        data.hardLevel = hardLevel;
        foreach (var item in objects)
        {
            data.objects.Add(item.GetData());
        }
        return data;
    }
    private void OnDrawGizmos()
    {

        drowLine(transform.position, Color.red);
        Gizmos.DrawSphere(transform.position + (Vector3.up * height), 0.2f);

        void drowLine(Vector3 pos, Color color)
        {
            Gizmos.color = color;
            Gizmos.DrawLine(pos + (Vector3.left * 5), pos + (-Vector3.left * 5));
        }

    }
}
