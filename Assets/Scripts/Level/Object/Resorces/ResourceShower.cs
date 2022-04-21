using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceShower : MonoBehaviour
{

    public Text text;

    public virtual void Set(int num)
    {
        text.text = num.ToString();
    }
    
    

}
