using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGizmos : MonoBehaviour
{

    public float ScreenWidth = 10;
    public float drowHeight = 30;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawRay(new Vector3(ScreenWidth / 2, 0, 0), Vector3.up * drowHeight);
        Gizmos.DrawRay(new Vector3(-ScreenWidth / 2, 0, 0), Vector3.up * drowHeight);
    }
}
