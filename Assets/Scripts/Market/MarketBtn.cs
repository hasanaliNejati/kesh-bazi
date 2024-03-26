
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MarketBtn : MonoBehaviour
{
    [SerializeField] private ResourceManager.ResourceType resourceType;
    [SerializeField] private int value;
    [SerializeField] private string key;

    public UnityEvent purchasSuccessfuly;
    public UnityEvent purchasFailed;

    private void Start()
    {
        if (GetComponent<Button>())
        {
            GetComponent<Button>().onClick.AddListener(Click);
        }
    }

    public void Click()
    {

        MarketManager.Instance.Buy(key, () =>
        {
            FindObjectOfType<ResourceManager>().AddResource(resourceType, value, Camera.main.ScreenToViewportPoint(transform.position));
            purchasSuccessfuly?.Invoke();  
        }, (string s) =>
        {
            print("no" + s);
            purchasFailed.Invoke();
        });
    }

}
