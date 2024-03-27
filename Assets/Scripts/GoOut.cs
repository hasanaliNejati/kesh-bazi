using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class GoOut : MonoBehaviour
{
    [SerializeField] private PanelScript panel;




    public void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            panel.SetActive(true);
        }
    }

    public void GoOutGame()
    {
        Application.Quit();
    }

}
