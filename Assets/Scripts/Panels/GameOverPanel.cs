using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private Text massageText;
    [SerializeField] private Text massageDataText;


    public void ShowPanel(string massage,string massageDetail)
    {
        GetComponent<PanelScript>().SetActive(true);
        massageText.text = massage;
        massageDataText.text = massageDetail;
    }
}
