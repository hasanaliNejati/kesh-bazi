using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentObjectGenerator : MonoBehaviour
{
    [Header("values")]
    [SerializeField] private float minYOffset;
    [SerializeField] private float maxYOffset;
    [SerializeField] private float xOffset;
    [SerializeField] private float startHeight = 15;
    [Header("objects")]
    [SerializeField] private EnvironmentObject[] environmentObjects;
    // Start is called before the first frame update
    void Start()
    {
        Generate(150);

    }

    public void Generate(float hight)
    {
        for (float _hight = startHeight; _hight < hight;)
        {
            _hight += Random.Range(minYOffset, maxYOffset);
            var obj = environmentObjects[Random.Range(0, environmentObjects.Length)];
            Instantiate(obj
                , new Vector3(Random.Range(-xOffset, xOffset), _hight)
                , obj.transform.rotation
                , transform);

        }
    }
}
