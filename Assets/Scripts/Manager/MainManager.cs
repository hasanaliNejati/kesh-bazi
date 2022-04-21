using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MainManager : MonoBehaviour
{
    
    public UnityEvent OnStartGame;
    public Character character;
    public InputPanel inputPanel;
    public PanelScript menuPanel;
    public PanelScript gameplayPanel;
    public PanelScript victoryPanel;
    public PanelScript gameoverPanel;

    
    private void Awake()
    {
        Time.timeScale = 1;
        Character c = Instantiate(character, Vector3.zero, new Quaternion());
        c.inputPanel = inputPanel;
    }


    public void StartGame()
    {
        OnStartGame.Invoke();
        menuPanel.SetActive(false);
        gameplayPanel.SetActive(true);

        if(GetComponent<LevelManager>().currentLevelType == LevelType.fast)
            FindObjectOfType<BackgroundMusic>()?.ChangeAudio(1);
    }

    bool _owner_victory = false;
    public void Victory()
    {
        if (_owner_victory)
            return;
        _owner_victory = true;

        SaveManager.level += 1;
        victoryPanel.SetActive(true);
        FindObjectOfType<BackgroundMusic>()?.ChangeAudio(0);
    }

    bool _owner_gameover = false;
    public void GameOver()
    {
        if (_owner_gameover)
            return;
        _owner_gameover = true;


        gameoverPanel.SetActive(true);

        FindObjectOfType<BackgroundMusic>()?.ChangeAudio(0);
        
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
    }

    public void coninuesGame()
    {
        Time.timeScale = 1;
      
    }
}
