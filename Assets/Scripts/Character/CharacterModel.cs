using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
public class CharacterModel : MonoBehaviour
{

    public int price;
    public bool gemType;
    [Space (15)]
    [Header("custom")]
    public int targetCustomIndex;
    //anchor
    public bool customAnchor;
    public Transform[] anchors;

    //line
    public bool customLine;
    public Line Line;

    //coustom feedback
    public bool customFeedback;
    public MMFeedbacks shootFeedback;
    public MMFeedbacks pullFeedback;
    public MMFeedbacks spownFeedback;

}
