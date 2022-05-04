using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentObject : MonoBehaviour
{
    [Header("Sprite")]
    public SpriteRenderer spriteRenderer;

    [Space(10)]
    [Header("COLOR")]
    [SerializeField] private Color colorNear = Color.white;
    [SerializeField] private Color colorFar = Color.white;
    [Header("Paralax")]
    [Range(0,1)]
    [SerializeField] private float minParallax;
    [Range(0, 1)]
    [SerializeField] private float maxParallax;
    [Header("size")]
    [SerializeField] private float minSize = 0.5f;
    [SerializeField] private float maxSize = 2;


    //LOGIC
    private Vector2 startPos;
    private Transform _cam;
    private Transform cam
    {
        get
        {
            return _cam ? _cam : _cam = FindObjectOfType<Camera>().transform;
        }
    }
    private float parallaxEffect;

    private void Start()
    {
        //start pos
        startPos = transform.position;
        //paralax
        parallaxEffect = Random.Range(minParallax, maxParallax);
        //color
        spriteRenderer.color = Color.Lerp(colorNear, colorFar, parallaxEffect/maxParallax);
        //size
        transform.localScale = Vector3.one * Random.Range(minSize, maxSize);
    }

    void Update()
    {
        transform.position = Vector2.Lerp(startPos,new Vector2(startPos.x, cam.position.y), parallaxEffect);
    }


    public void SetSpeed(Vector2 Speed)
    {

    }
}
