using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public delegate void VoidDelegate_vector2(Vector2 v);
public delegate void VoidDelegate();

public class InputPanel : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{


    public UnityEvent OnStartGame;
    bool gameStarted;


    PointerEventData data;
    Vector2 clickPos;
    Vector2 correntPos;

    VoidDelegate_vector2 down;
    VoidDelegate_vector2 stay;
    VoidDelegate_vector2 up;

    public void setEvents(VoidDelegate_vector2 down,VoidDelegate_vector2 stay,VoidDelegate_vector2 up)
    {
        this.down += down;
        this.stay += stay;
        this.up += up;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
        data = eventData;
        clickPos = data.position;
        down(clickPos);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        up(eventData.position);
        data = null;
    }


    private void Update()
    {
        if (data != null)
        {
            correntPos = data.position;
            if (!gameStarted && 
                (Camera.main.ScreenToWorldPoint(clickPos) - Camera.main.ScreenToWorldPoint(correntPos)).magnitude > 1f)
            {
                print(Camera.main.ScreenToWorldPoint(clickPos - correntPos).magnitude);
                gameStarted = true;
                OnStartGame.Invoke();
            }
            stay(correntPos);
        }
    }

}
