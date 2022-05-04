using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
public class Resource : ChunkObject
{

    public ResourceManager.ResourceType type;
    public int num = 1;

    [Header("eat")]
    [SerializeField] private GameObject graphic;
    [SerializeField] private Collider2D _collider;
    [SerializeField] private float destroyTime = 2;

    [Header("Feedback")]
    [SerializeField] private MMFeedbacks eatFeedback;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            eat();
        }
    }

    public virtual void eat()
    {
        FindObjectOfType<ResourceManager>().AddResource(type, num,Camera.main.WorldToViewportPoint(transform.position));
        eatFeedback?.PlayFeedbacks();
        _collider.enabled = false;
        graphic?.SetActive(false);
        Destroy(gameObject,destroyTime);
    }
}
