using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;


public class ResourceShowerByAnimation : ResourceShower
{
    [SerializeField] ResourceGetGraphic resourceGraphic;
    [SerializeField] Transform direction;
    [Header("Feedback")]
    [SerializeField] MMFeedbacks addFeedback;
    [SerializeField] MMFeedbacks lowFeedback;
    //LOGIC
    int count;
    int courrectCount;
    List<ResourceGetGraphic> graphics = new List<ResourceGetGraphic>();
    List<ResourceGetGraphic> objectPoll = new List<ResourceGetGraphic>();
    public override void Set(int num, bool forced = false, Vector2 viewportPos = default)
    {
        //forced
        if (forced)
        {
            text.text = num.ToString();
            count = num;
            courrectCount = num;
            return;
        }

        //low
        if (num < count)
        {
            lowFeedback?.PlayFeedbacks();
            text.text = num.ToString();
            count = num;
            courrectCount = num;
            return;
        }
        //get
        count = num;

        GenerateGraphic(viewportPos);

    }

    void GenerateGraphic(Vector2 viewportPos)
    {
        ResourceGetGraphic rgg = null;
        foreach (var item in objectPoll)
        {
            if (item.gameObject.activeSelf == false)
            {
                rgg = item;
                break;
            }
        }
        if (rgg == null)
        {
            rgg = Instantiate(resourceGraphic, transform);
            objectPoll.Add(rgg);
        }
        rgg.SetDistenation(viewportPos, Camera.main.ScreenToViewportPoint(direction.position), GetGeraphicalResource);
        graphics.Add(rgg);
    }

    public void GetGeraphicalResource(ResourceGetGraphic rgg)
    {
        addFeedback?.PlayFeedbacks();
        courrectCount++;
        graphics.Remove(rgg);
        if (graphics.Count == 0)
            courrectCount = count;
        text.text = courrectCount.ToString();

    }
}
