using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinGizmos : MonoBehaviour
{

    public float distance = 3;

    private void OnDrawGizmos()
    {

        Pin[] pins = FindObjectsOfType<Pin>();



        foreach (Pin pin in pins)
        {
            Gizmos.DrawWireSphere(pin.transform.position, distance);
        }
    }

    
}
