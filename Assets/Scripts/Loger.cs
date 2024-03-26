using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Loger : MonoBehaviour
{
    private static Loger _instance;
    public static Loger Instance {  get { return _instance ? _instance : _instance = FindObjectOfType<Loger>(); } }


    [SerializeField] private TextMeshProUGUI ErrorLog;

    public void LogError(string error)
    {
        ErrorLog.text = error;
        ErrorLog.gameObject.SetActive(false);
        ErrorLog.gameObject.SetActive(true);
    }


}
