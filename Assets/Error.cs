using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Error : MonoBehaviour
{




    public void Play()
    {
        //Loger.Instance.LogError("Payment failed!!");
        Loger.Instance.LogError("خرید ناموفق بود!!");
    }
    //[SerializeField] private AudioSource errorSuonde;
    //[SerializeField] private Animator errorAnim;
    //[SerializeField] private PanelScript errorObject;
    //[SerializeField] private float timeEnd;

    //public void Play()
    //{
    //    errorObject.SetActive(true);
    //    errorAnim.Play("Error");
    //    errorSuonde.Play();
    //    StartCoroutine(Timer());
    //}


    //private IEnumerator Timer()
    //{
    //   yield return new WaitForSeconds(timeEnd);
    //    errorObject.SetActive(false);
    //}

}
