using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RTLTMPro;
public class Loger : MonoBehaviour
{
    private static Loger _instance;
    public static Loger Instance {  get { return _instance ? _instance : _instance = FindObjectOfType<Loger>(); } }


    //[SerializeField] private TextMeshProUGUI ErrorLog;
    [SerializeField] private RTLTextMeshPro errorLog;
    public void LogError(string error)
    {
        //ErrorLog.text = error;
        //ErrorLog.gameObject.SetActive(false);
        //ErrorLog.gameObject.SetActive(true);

        errorLog.text = error;
        errorLog.gameObject.SetActive(false);
        errorLog.gameObject.SetActive(true);
    }


}
