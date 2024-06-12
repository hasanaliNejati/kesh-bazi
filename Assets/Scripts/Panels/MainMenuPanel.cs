using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using RTLTMPro;
public class MainMenuPanel : MonoBehaviour
{

    //[SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private RTLTextMeshPro rTLTextMeshProLevelText;
    private void Start()
    {
        rTLTextMeshProLevelText.text = "مرحله " + SaveManager.level;
    }

}
