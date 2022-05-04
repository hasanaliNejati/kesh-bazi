using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Loger : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ErrorLog;

    public void LogError(string error)
    {
        ErrorLog.text = error;
        ErrorLog.gameObject.SetActive(false);
        ErrorLog.gameObject.SetActive(true);
    }
}
