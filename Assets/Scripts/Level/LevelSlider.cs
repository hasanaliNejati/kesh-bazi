using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSlider : MonoBehaviour
{

    GameObject _character;
    GameObject character
    {
        get { return _character ? _character : _character = GameObject.FindGameObjectWithTag("Player"); }
    }
    public Slider slider;
    public Text levelText;
    public Text nextLevelText;
    float characterY;

    private void Start()
    {
        levelText.text = SaveManager.level.ToString();
        nextLevelText.text = (SaveManager.level + 1).ToString();
    }


    void Update()
    {
        if (!character)
            return;
        characterY = Mathf.Clamp(character.transform.position.y, characterY, 1);

        float amound = characterY / 1;

        slider.value = amound;
    }
}
