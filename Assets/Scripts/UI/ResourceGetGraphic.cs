using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using MoreMountains.Feedbacks;
public delegate void VoidDelegate_ResourceGetGraphic(ResourceGetGraphic rgg);

public class ResourceGetGraphic : MonoBehaviour
{
    [SerializeField] float time = 2;
    [SerializeField] float curveOffset = 0.3f;
    [SerializeField] GameObject graphic;
    [SerializeField] MMFeedbacks endMoveFeedback;

    //LOGIC
    private Vector2 startPos;
    private Vector2 distenation;
    private Vector2 curvePos;
    private VoidDelegate_ResourceGetGraphic endMove;
    private Camera _cam;
    private Camera cam
    {
        get
        {
            return _cam ? _cam : _cam = Camera.main;
        }
    }
    private float _time;
    bool moveEnded;


    private void Update()
    {
        if (moveEnded)
            return;

        _time += Time.deltaTime;
        float moveAmound = _time / time;

        var pos1 = Vector2.Lerp(startPos, curvePos, moveAmound);
        var pos2 = Vector2.Lerp(curvePos, distenation, moveAmound);
        transform.position = Vector2.Lerp(pos1, pos2, moveAmound);

        if (_time >= time)
        {
            moveEnded = true;
            endMove(this);
            endMoveFeedback.PlayFeedbacks();
            StartCoroutine(disable());
        }
    }

    public void SetDistenation(Vector2 startViewportPos, Vector2 distenationViewport, VoidDelegate_ResourceGetGraphic endMove)
    {
        //reset
        _time = Random.Range(-0.3f,0.3f);
        moveEnded = false;
        //enable
        gameObject.SetActive(true);
        graphic.SetActive(true);

        //set start pos
        this.startPos = GetScreenPos(startViewportPos);
        transform.position = this.startPos;
        //set distenation
        this.distenation = GetScreenPos(distenationViewport);
        //random curve pos
        var curveViewport = new Vector2(
            Random.Range(startViewportPos.x - curveOffset, startViewportPos.x + curveOffset),
            Random.Range(startViewportPos.y - curveOffset, startViewportPos.y + curveOffset));
        this.curvePos = GetScreenPos(curveViewport);
        //event
        this.endMove = endMove;
    }

    private Vector2 GetScreenPos(Vector2 viewportPos)
    {
        return cam.ViewportToScreenPoint(viewportPos);
    }

    IEnumerator disable()
    {
        graphic.SetActive(false);

        yield return new WaitForSeconds(1);

        gameObject.SetActive(false);
    }

}
