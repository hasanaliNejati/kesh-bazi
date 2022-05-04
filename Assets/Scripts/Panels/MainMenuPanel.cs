using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MainMenuPanel : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI levelText;

    private void Start()
    {
        levelText.text = "Level " + SaveManager.level;
    }

}
