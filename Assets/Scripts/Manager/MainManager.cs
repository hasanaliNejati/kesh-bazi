using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.Events;
using MoreMountains.Feedbacks;
public class MainManager : MonoBehaviour
{

    public UnityEvent OnStartGame;
    public UnityEvent OnEndGame;
    public Character character;
    public InputPanel inputPanel;
    public PanelScript menuPanel;
    public PanelScript gameplayPanel;
    public VictoryPanel victoryPanel;
    public GameOverPanel gameoverPanel;

    [Header("Feedbacks")]
    [SerializeField] private MMFeedbacks gameOverFeedback;
    [SerializeField] private MMFeedbacks victoryFeedback;

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

        if (GetComponent<LevelManager>().currentLevelType == LevelType.fast)
            FindObjectOfType<BackgroundMusic>()?.ChangeAudio(1);

        var dictionaryData = new Dictionary<string, object>
        {
            { "level", SaveManager.level }
        };
         AnalyticsResult result = Analytics.CustomEvent("start Game", dictionaryData);
        print("analytics : " + result);
    }

    bool _owner_endGame = false;
    public void Victory()
    {
        if (_owner_endGame)
            return;
        _owner_endGame = true;
        OnEndGame.Invoke();
        victoryPanel.ShowPanel(SaveManager.level);
        SaveManager.level += 1;
        FindObjectOfType<BackgroundMusic>()?.ChangeAudio(0);

        victoryFeedback.PlayFeedbacks();
    }

    public void GameOver(string massage,string massageDetail)
    {
        if (_owner_endGame)
            return;
        _owner_endGame = true;
        OnEndGame.Invoke();


        gameoverPanel.ShowPanel(massage,massageDetail);

        FindObjectOfType<BackgroundMusic>()?.ChangeAudio(0);

        gameOverFeedback.PlayFeedbacks();

        var dictionaryData = new Dictionary<string, object>
        {
            { "level", SaveManager.level },
            { "massage", massage },
            { "charater pos", (int)character.transform.position.y }
        };
        AnalyticsResult result = Analytics.CustomEvent("start Game", dictionaryData);
        print("analytics : " + result);
    }

    public void pauseGame()
    {
        if (_owner_endGame)
            return;
        Time.timeScale = 0;
    }

    public void coninuesGame()
    {
        Time.timeScale = 1;
    }
}
