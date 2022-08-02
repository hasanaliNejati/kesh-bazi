using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private void Start()
    {
        Vector3[] v3 = new Vector3[GetComponent<LineRenderer>().positionCount];
        GetComponent<LineRenderer>().GetPositions(v3);
        foreach (var item in v3)
        {
            print(item);
        }
    }

    private void Update()
    {
        print("------------------------");
    }
}
