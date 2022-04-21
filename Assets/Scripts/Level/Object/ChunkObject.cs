using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

public class ChunkObject : MonoBehaviour
{
    [HideInInspector] public string object_tag = "";
    internal string otherData;
    public ObjectData GetData()
    {
        var data = new ObjectData();
        data.object_tag = object_tag;
        data.pos = transform.localPosition;
        data.angle = transform.rotation.eulerAngles.z;
        data.otherData_json = GetOtherData();
        return data;
    }

    protected virtual string GetOtherData()
    {
        return "";
    }
}
