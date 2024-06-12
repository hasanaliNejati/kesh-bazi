using MoreMountains.Feedbacks;
using RTLTMPro;
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
            if (collision.GetComponent<EnemyMassage>())
            {
                var massager = collision.GetComponent<EnemyMassage>();
                Die(massager.deathMassage, massager.deathMassageDetail);
            }else
            Die();
        }
    }

    bool deathed;
    public void Die(string massage = "مراقب باش" , string massageDetail = "حواستو بیشتر جمع کن!")
      
    {
        if (deathed)
            return;
        FindObjectOfType<MainManager>().GameOver(massage,massageDetail);
        var character = GetComponent<Character>();
        character.rb.simulated = false;
        character.connectedPin = null;
        graphic.SetActive(false);
        dieFeedback.PlayFeedbacks();
        deathed = true;
    }
}
