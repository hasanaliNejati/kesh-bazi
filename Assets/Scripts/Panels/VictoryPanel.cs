using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Feedbacks;
public class VictoryPanel : MonoBehaviour
{
    [Header("Gift")]
    [SerializeField] private int candyGift = 20;
    [SerializeField] private int gemGift = 1;
    [Header("elemans")]
    [SerializeField] private Text correntLevelNumText;
    [SerializeField] private Text nextLevelNumText;
    [SerializeField] private Text candyGiftText;
    [SerializeField] private Text gemGiftText;
    [Space(10)]
    [Header("advance graphic gift")]
    [SerializeField] Transform candyGiftPos;
    [SerializeField] MMFeedbacks candyFeedback;
    [SerializeField] float candyStartTime = 2;
    [SerializeField] float candyDelay = 0.1f;
    [SerializeField] Transform gemGiftPos;
    [SerializeField] MMFeedbacks gemFeedback;
    [SerializeField] float gemStartTime = 3.3f;
    [SerializeField] float gemDelay = 0.2f;
    //LOGIC
    int candyGetedGift;
    int gemGetedGift;
    ResourceManager _rm;
    ResourceManager rm
    {
        get
        {
            return _rm ? _rm : _rm = FindObjectOfType<ResourceManager>();
        }
    }
    Camera _cam;
    Camera cam
    {
        get
        {
            return _cam ? _cam : _cam = Camera.main;
        }
    }
    public void ShowPanel(int correntLevel)
    {
        candyGiftText.text = candyGift.ToString();
        gemGiftText.text = gemGift.ToString();
        correntLevelNumText.text = correntLevel.ToString();
        nextLevelNumText.text = (correntLevel + 1).ToString();
        GetComponent<PanelScript>().SetActive(true);
        StartCoroutine(SetGift(ResourceManager.ResourceType.candy, candyStartTime));
        StartCoroutine(SetGift(ResourceManager.ResourceType.gem, gemStartTime));
    }

    IEnumerator SetGift(ResourceManager.ResourceType type, float delay)
    {
        yield return new WaitForSeconds(delay);

        switch (type)
        {
            case ResourceManager.ResourceType.candy:
                if (candyGetedGift < candyGift)
                {
                    candyGetedGift++;
                    rm.AddResource(type, 1,cam.ScreenToViewportPoint(candyGiftPos.position));
                    candyFeedback.PlayFeedbacks();
                    StartCoroutine(SetGift(type, candyDelay));
                    
                }
                break;
            case ResourceManager.ResourceType.gem:
                if (gemGetedGift < gemGift)
                {
                    gemGetedGift++;
                    rm.AddResource(type, 1, cam.ScreenToViewportPoint(gemGiftPos.position));
                    gemFeedback.PlayFeedbacks();
                    StartCoroutine(SetGift(type, gemDelay));
                }
                break;
            default:
                break;
        }

    }

    private void OnDisable()
    {
        SaveManager.candy += candyGift - candyGetedGift;
        SaveManager.gem += gemGift - gemGetedGift;

    }
}
