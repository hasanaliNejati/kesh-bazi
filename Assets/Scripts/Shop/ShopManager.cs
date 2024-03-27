using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameObject nextBtn;
    [SerializeField] private GameObject backBtn;
    [SerializeField] private BuyBtn buyBtn;

    [Space(10)]
    [Header("Feedbacks")]
    [SerializeField] private MMFeedbacks buyFeedback;
    [SerializeField] private MMFeedbacks resourceNotEnoughFeedback;


    //Logic
    private Character _character;
    public Character character
    {
        get { return _character ? _character : _character = FindObjectOfType<Character>(); }
    }

    private ResourceManager _resourceManager;
    public ResourceManager resourceManager
    {
        get { return _resourceManager ? _resourceManager : _resourceManager = GetComponent<ResourceManager>(); }
    }

    private Loger _loger;
    public Loger loger
    {
        get { return _loger ? _loger : _loger = GetComponent<Loger>(); }
    }
    private int selectedIndex;

    public void StartShop()
    {
        selectedIndex = SaveManager.selectedCharacter;
        UpdateInfo();
    }
    public void Next()
    {
        selectedIndex++;
        character.SetCharacterModelIndex(selectedIndex);
        UpdateInfo();
    }
    public void Back()
    {
        selectedIndex--;
        character.SetCharacterModelIndex(selectedIndex);
        UpdateInfo();
    }
    public void UpdateInfo()
    {
        backBtn.SetActive(selectedIndex != 0);
        nextBtn.SetActive(selectedIndex < (character.characterModels.Length - 1));
        if (SaveManager.CheckBouhgtCharacter(selectedIndex))
        {
            buyBtn.SetActive(false);
            //select
            SaveManager.selectedCharacter = selectedIndex;
        }
        else
        {
            buyBtn.SetActive(true);
            int price = character.characterModels[selectedIndex].price;
            bool gemType = character.characterModels[selectedIndex].gemType;
            buyBtn.SetData(price, gemType);
        }
    }
    public void Buy()
    {
        int price = character.characterModels[selectedIndex].price;
        bool gemType = character.characterModels[selectedIndex].gemType;
        if (gemType)
        {
            if (price <= SaveManager.gem)
            {
                //buy
                SaveManager.BuyCharacter(selectedIndex);
                //low of resorce
                resourceManager.AddResource(ResourceManager.ResourceType.gem, -price,new Vector2());
                //update data
                UpdateInfo();
                //feedback
                buyFeedback.PlayFeedbacks();

                AppMetrica.Instance.ReportEvent("buy character", new Dictionary<string, object> { { "index", selectedIndex } });

            }
            else
            {
                resourceNotEnoughFeedback.PlayFeedbacks();
                loger.LogError("gem not enough!!");
            }
        }
        else
        {
            if (price <= SaveManager.candy)
            {
                //buy
                SaveManager.BuyCharacter(selectedIndex);
                //low of resorce
                resourceManager.AddResource(ResourceManager.ResourceType.candy, -price,new Vector2());
                //update data
                UpdateInfo();

                //feedback
                buyFeedback.PlayFeedbacks();

                AppMetrica.Instance.ReportEvent("buy character", new Dictionary<string, object> { { "index", selectedIndex } });

            }
            else
            {
                resourceNotEnoughFeedback.PlayFeedbacks();
                loger.LogError("candy not enough!!");
            }
        }
    }
    public void CloseShop()
    {
        if (selectedIndex != SaveManager.selectedCharacter)
            character.SetCharacterModelIndex(SaveManager.selectedCharacter,false);
        buyBtn.SetActive(false);
    }
}
