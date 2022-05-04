using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{

    private float startPos;
    public GameObject cam;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {

        float distance = (cam.transform.position.x * parallaxEffect);
        if (cam.transform.position.x >= 1.03 && cam.transform.position.x <= 30.42)
        {
            transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);

        }
    }
}
