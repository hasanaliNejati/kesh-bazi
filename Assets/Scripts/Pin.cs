using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
public class Pin : ChunkObject
{
    [SerializeField] private MMFeedbacks connectFeedback;
    public Vector2 position { get { return transform.position; } }

    public void Connect()
    {
        connectFeedback.PlayFeedbacks();
    }

}
