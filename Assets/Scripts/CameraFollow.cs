using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Camera cam;
    public bool follow = false;
    public bool fasterMod = false;
    public float fasterSpeed = 2;
    
    Character _character;
    public Character character
    {
        get { return _character ? _character : _character = FindObjectOfType<Character>(); }
    }
    public float offsetInFree = 0;
    public float offsetInConnect = 3;
    public float offsetInFaster = -3;
    public float speed = 10;
    public float sizeSpeed = 5;
    float minPosY;

    [System.Serializable]
    public struct Style
    {
        public Style(float size,float position)
        {
            this.size = size;
            this.position = position;
        }
        public float size;
        public float position;
    }
    public Style shopStyle;



    //LOGIC
    //camera
    CinemachineVirtualCamera _cinemachineCam;
    CinemachineVirtualCamera cinemachineCam
    {
        get
        {
            return _cinemachineCam ? _cinemachineCam : _cinemachineCam = GetComponent<CinemachineVirtualCamera>();
        }
    }

    private Style defaultStyle;

    private Style correntStyle;

    private void Start()
    {
        minPosY = transform.position.y;

        defaultStyle = new Style(cam.orthographicSize, transform.position.y);
        SetStyle(defaultStyle);
    }

    public void SetActive(bool active)
    {
        follow = active;
    }

    public void SetStyle(Style style)
    {
        correntStyle = style;
    }

    #region style functions
    public void setShopStyle()
    {
        correntStyle = shopStyle;
    }
    public void setDefaultStyle()
    {
        correntStyle = defaultStyle;
    }
    #endregion

    private void FixedUpdate()
    {
        cinemachineCam.m_Lens.OrthographicSize = Mathf.Lerp(cam.orthographicSize, correntStyle.size, sizeSpeed * Time.deltaTime);

        if (!follow || !character)
        {
            transform.position = Vector3.Lerp(transform.position,
                new Vector3(transform.position.x,
                correntStyle.position,
                transform.position.z),
                speed * Time.deltaTime);
            return;
        }
        else if (correntStyle.size != defaultStyle.size)
            correntStyle = defaultStyle;

        if (fasterMod)
        {

        }
        else
        {

            float y = 0;
            float offset = 0;
            if (character.connected)
            {
                y = character.connectedPin.position.y;
                offset = offsetInConnect;
            }
            else
            {
                y = Mathf.Clamp(character.transform.position.y, minPosY, character.transform.position.y);
                offset = offsetInFree;
            }
            minPosY = y;
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, minPosY + offset, transform.position.z), speed * Time.deltaTime);
        }

        
       
    }
    private void LateUpdate()
    {
        if (!follow || !character)
            return;
        if (fasterMod)
        {
            if (character.transform.position.y > (transform.position.y - offsetInFaster))
                transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, character.transform.position.y + offsetInFaster, transform.position.z), Time.deltaTime * speed);
            transform.Translate(0, Time.deltaTime * fasterSpeed, 0);

        }
    }


}
