using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chunk : MonoBehaviour
{
   public float height;
    public int minLevle;

    private void OnDrawGizmos()
    {

        Debug.DrawLine(new Vector3(transform.position.x-10,transform.position.y+height), new Vector3(transform.position.x + 10, transform.position.y + height));

    }
}
