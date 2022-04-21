using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public bool follow = false;
    public bool fasterMod = false;
    public float fasterSpeed = 2;
    public void SetActive(bool active)
    {
        follow = active;
    }
    Character _character;
    public Character character
    {
        get { return _character ? _character : _character = FindObjectOfType<Character>(); }
    }
    public float offsetInFree = 0;
    public float offsetInConnect = 3;
    public float offsetInFaster = -3;
    public float speed = 10;
    float minPosY;


    private void Start()
    {
        minPosY = transform.position.y;
    }
    private void FixedUpdate()
    {
        if (!follow || !character)
            return;
        if (fasterMod)
        {
            //if (target.transform.position.y > (transform.position.y - offsetInFaster))
            //    transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, target.transform.position.y + offsetInFaster, transform.position.z),Time.deltaTime * speed);
            //transform.Translate(0, Time.deltaTime * fasterSpeed, 0);
            //print(Time.deltaTime);

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
            print(Time.deltaTime);

        }
    }
}
