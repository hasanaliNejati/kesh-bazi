using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;
using Cinemachine;
//[RequireComponent(typeof(Camera))]
public class ScreenWall : MonoBehaviour
{
    Character _character;
    public Character character
    {
        get { return _character ? _character : _character = FindObjectOfType<Character>(); }
    }
    public float characterRadius;
    public float dieWallOffste = 2;
    [Header("feedback")]
    [SerializeField] private MMFeedbacks teleportFeedback;
    Vector2 cameraSize;

   
    private void Start()
    {
        float characterOffset = character.transform.position.z - transform.position.z;
        cameraSize = (Camera.main.ViewportToWorldPoint(new Vector3(1, 1, characterOffset)) - transform.position);
        

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
            var newPos = new Vector3(-character.transform.position.x, character.transform.position.y, character.transform.position.z);
            character.transform.position = newPos;
            teleportFeedback.PlayFeedbacks(newPos);
        }
        maximumWidth = Mathf.Clamp(Mathf.Abs(characterPosX) + 0.1f, this.cameraSize.x + characterRadius,500);



        float characterPosY = character.transform.position.y - transform.position.y;
        if (characterPosY < -(cameraSize.y + dieWallOffste) && (!character.connected || GetComponent<CameraFollow>().fasterMod))
        {
            character.GetComponent<DieCharacter>().Die("You fell down!!");
        }

    }



}
