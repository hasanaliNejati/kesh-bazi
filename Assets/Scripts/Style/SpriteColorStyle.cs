using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteColorStyle : MonoBehaviour
{
    [System.Serializable]
    public struct StyleData
    {
        public int minLevel;
        public Sprite sprite;
        public Color color;
    }
    public StyleData[] styles;
    public StyleData fasterStyle;
    public float changeColorSpeed = 5;
    //LOGIC
    SpriteRenderer _sprite;
    private bool gameStarted;

    SpriteRenderer sprite
    {
        get
        {
            return _sprite ? _sprite : _sprite = GetComponent<SpriteRenderer>();
        }
    }

    private void Start()
    {
        FindObjectOfType<MainManager>().OnStartGame.AddListener(StartGame);
    }
    public void StartGame()
    {
        gameStarted = true;
    }

    void Update()
    {
        if (!gameStarted)
            return;
        if (FindObjectOfType<LevelManager>().currentLevelType == LevelType.fast)
        {
            sprite.color = Color.Lerp(sprite.color, fasterStyle.color, Time.deltaTime * changeColorSpeed);
        }
    }

}
