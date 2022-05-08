using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTutorial : MonoBehaviour
{
    public Transform[] points;
    public LineRenderer line;
    [SerializeField] private GameObject obj;
    [SerializeField] private float enableTime = 5;

    
   
    IEnumerator StartTutorial()
    {
        if (SaveManager.GetInt("main tutorial") == 0)
        {
            obj.SetActive(true);
            SaveManager.SetInt("main tutorial", 1);
        }
        yield return new WaitForSeconds(enableTime);
        obj.SetActive(true);
    }

    

    private void OnEnable()
    {
        obj.SetActive(false);
        StartCoroutine(StartTutorial());
    }
    private void Update()
    {
        Vector3[] positions = new Vector3[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            positions[i] = points[i].transform.position;
        }
        line.SetPositions(positions);
    }
}
