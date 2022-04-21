using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class CharacterFace : MonoBehaviour
{


    public FaceAnim face;
    
    Character _character;
    Character character
    {
        get { return _character ? _character :_character = GetComponent<Character>(); }
    }



    private void LateUpdate()
    {
        if (character.posControlActive)
        {
            face.target = character.connectedPin.position;

        }
        else
        {
            face.useTarget = false;
        }
    }
}
