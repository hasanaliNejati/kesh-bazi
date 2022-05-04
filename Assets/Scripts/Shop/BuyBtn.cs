using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyBtn : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private GameObject candyIcon;
    [SerializeField] private GameObject gemIcon;

    //LOGIC
    private PanelScript _panel;
    private PanelScript panel
    {
        get
        {
            return _panel ? _panel : _panel = GetComponent<PanelScript>();
        }
    }

    public void SetData(int price,bool gem)
    {
        priceText.text = price.ToString();
        candyIcon.SetActive(!gem);
        gemIcon.SetActive(gem);

    }

    public void SetActive(bool active)
    {
        panel.SetActive(active);
    }


}
