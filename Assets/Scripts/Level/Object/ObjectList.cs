using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Object list",menuName = "ScriptableObjects/Object list",order = 1)]
public class ObjectList : ScriptableObject
{
    [System.Serializable]
    public struct Obj
    {
        public string tag;
        public ChunkObject chunkObject;
    }
    public List<Obj> objs = new List<Obj>();

    public ChunkObject GetObject(string name)
    {
        foreach (var item in objs)
        {
            if (item.tag == name)
                return item.chunkObject;
        }
        Debug.LogError("name not found!");
        return null;
    }
}
