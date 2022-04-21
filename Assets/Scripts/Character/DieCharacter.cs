using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieCharacter : MonoBehaviour
{
    [SerializeField] private GameObject graphic;
    [Space(10)]
    [Header("Feedbacks")]
    [SerializeField] private MMFeedbacks dieFeedback;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemy")
        {
            Die();
        }
    }

    public void Die()
    {
        FindObjectOfType<MainManager>().GameOver();
        var character = GetComponent<Character>();
        character.rb.simulated = false;
        character.connectedPin = null;
        graphic.SetActive(false);
        dieFeedback.PlayFeedbacks();
    }
}
