using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

public class ChunkObject : MonoBehaviour
{
    [HideInInspector] public string object_tag = "";
    protected string otherData;
    public ObjectData GetData()
    {
        var data = new ObjectData();
        data.object_tag = object_tag;
        data.pos = transform.localPosition;
        data.angle = transform.rotation.eulerAngles.z;
        data.otherData_json = otherData;
        return data;
    }

    

    public virtual void SetOtherData(string data)
    {
        otherData = data;
    }
}
