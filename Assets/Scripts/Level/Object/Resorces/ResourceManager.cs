using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{


    public ResourceShower candyShower;
    public ResourceShower gemShower;

    [System.Serializable]
    public enum ResourceType
    {
        candy, gem
    }


    private void Start()
    {
        takeCandy(0);
        takeGem(0);
    }

    public void AddResource(ResourceType type,int num)
    {
        switch (type)
        {
            case ResourceType.candy:
                takeCandy(num);
                break;
            case ResourceType.gem:
                takeGem(num);
                break;
        }
    }

    void takeCandy(int num)
    {
         SaveManager.candy += num;
        candyShower.Set(SaveManager.candy);
    }

    void takeGem(int num)
    {
        SaveManager.gem += num;
        gemShower.Set(SaveManager.gem);
    }


}
