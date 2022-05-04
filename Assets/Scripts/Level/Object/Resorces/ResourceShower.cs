using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceShower : MonoBehaviour
{
    
    public Text text;


    
    public virtual void Set(int num,bool forced = false,Vector2 viewportPos = new Vector2())
    {
        text.text = num.ToString();
    }


    
    

}
