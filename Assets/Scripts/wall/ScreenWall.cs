using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Camera))]
public class ScreenWall : MonoBehaviour
{
    Character _character;
    public Character character
    {
        get { return _character ? _character : _character = FindObjectOfType<Character>(); }
    }
    public float characterRadius;
    public float dieWallOffste = 2;
    Vector2 cameraSize;

    Camera _camera;
    Camera camera
    {
        get { return _camera ? _camera : _camera = GetComponent<Camera>(); }
    }

    private void Start()
    {
        float characterOffset = character.transform.position.z - transform.position.z;
        cameraSize = (camera.ViewportToWorldPoint(new Vector3(1, 1, characterOffset)) - transform.position);
        print(cameraSize);

    }

    float maximumWidth;
    float maximumHight;
    public void Update()
    {
        if (!character)
            return;
        float characterPosX = character.transform.position.x - transform.position.x;
        if (Mathf.Abs(characterPosX) > maximumWidth && !character.connected)
        {
            character.transform.position = new Vector3(-character.transform.position.x, character.transform.position.y, character.transform.position.z);
        }
        maximumWidth = Mathf.Clamp(Mathf.Abs(characterPosX), this.cameraSize.x + characterRadius,500);



        float characterPosY = character.transform.position.y - transform.position.y;
        if (characterPosY < -(cameraSize.y + dieWallOffste) && (!character.connected || GetComponent<CameraFollow>().fasterMod))
        {
            FindObjectOfType<MainManager>().GameOver();
        }

    }



}
