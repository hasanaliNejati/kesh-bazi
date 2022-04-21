using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveDeleter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            PlayerPrefs.DeleteAll();
            print("adw");
        }
    }
}
