using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstOpen : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        var key = "firstOpen";
        int f = PlayerPrefs.GetInt(key);
        if(f == 0)
        {
            AppMetrica.Instance.ReportEvent("first open");

            PlayerPrefs.SetInt(key, 2);
        }
    }
}
