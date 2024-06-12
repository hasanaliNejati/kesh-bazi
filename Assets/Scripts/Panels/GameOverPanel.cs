using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using RTLTMPro;

public class GameOverPanel : MonoBehaviour
{
    //[SerializeField] private Text massageText;
    //[SerializeField] private Text massageDataText;
    [SerializeField] private RTLTextMeshPro massageText;
    [SerializeField] private RTLTextMeshPro massageDataText;
    //[SerializeField] private string massage;
    public void ShowPanel(string massage , string massageDetail)
    {
        GetComponent<PanelScript>().SetActive(true);
        massageText.text = massage;
        //massage = massageText.text;
        //massageDetail = massageDataText.text;
        //massageText.text = this.massage;
        massageDataText.text = massageDetail;

    }
}
