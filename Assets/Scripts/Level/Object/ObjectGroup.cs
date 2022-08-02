using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGroup : ChunkObject
{
    public GameObject[] resources;


    public override void SetOtherData(string data)
    {
        otherData = data;
        int index = 0;
        if (!int.TryParse(data, out index))
            return;

        for (int i = 0; i < resources.Length; i++)
        {
            if (i == index)
                resources[i].SetActive(true);
            else
                resources[i].SetActive(false); 
        }
    }

    public void SellectRandomGroup()
    {
        int randomIndex = Random.Range(0, resources.Length);
        SetOtherData(randomIndex.ToString());
    }

    public void Next()
    {
        MoveToGroup(1);
    }
    public void Back()
    {
        MoveToGroup(-1);
    }
    
    private void MoveToGroup(int offsetIndex)
    {
        int courrentIndex = 0;
        int.TryParse(otherData, out courrentIndex);

        courrentIndex += offsetIndex;
        if (courrentIndex < 0 || courrentIndex >= resources.Length)
            return;

        SetOtherData(courrentIndex.ToString());
    }
}
