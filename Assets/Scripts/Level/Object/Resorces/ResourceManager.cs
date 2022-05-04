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

    //LOGIC

    private void Start()
    {
        candyShower.Set(SaveManager.candy, true);
        gemShower.Set(SaveManager.gem, true);
    }

    public void AddResource(ResourceType type,int num,Vector2 viewportPos)
    {
        switch (type)
        {
            case ResourceType.candy:
                takeCandy(num, viewportPos);
                break;
            case ResourceType.gem:
                takeGem(num, viewportPos);
                break;
        }
    }

    void takeCandy(int num,Vector2 viewportPos)
    {
        SaveManager.candy += num;
        candyShower.Set(SaveManager.candy,false,viewportPos);
    }

    void takeGem(int num,Vector2 viewportPos)
    {
        SaveManager.gem += num;
        gemShower.Set(SaveManager.gem,false,viewportPos);
    }


}
