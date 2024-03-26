using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;




namespace Mohammadali.WheelOfLuck
{


    [Serializable]
    public class GetPrizeUnityEvent : UnityEvent<Spin.Prize> { }


    public class Spin : MonoBehaviour
    {
        [Serializable]
        public class Prize
        {
            public Sprite Sprite;
            public string description;
            public UnityEvent OnGetPrize;
        }


        [SerializeField] private GetPrizeUnityEvent OnGetPrizeUnityEvent;
        [SerializeField] UnityEvent OnStartRolling;
        [Space(10)]

        [SerializeField] private float timeRotate;
        [SerializeField] private int numberCilrckeRotate;
        [Space(6)]
        [SerializeField] private AnimationCurve curve;
        [Space(10)]
        [SerializeField] private Prize[] prizeArray;



        private const float ANGLE_CIRCL = 360.0F;
        private float angleOfOnePrize;

        private float currentTimer;



        private void Start()
        {
            MakeSpinVisual();
            angleOfOnePrize = ANGLE_CIRCL / prizeArray.Length;
        }


        private IEnumerator ReotiteWheel()
        {

            currentTimer = 0;


            float startAngle = transform.eulerAngles.z;
            int indexPrizeRandom = Random.Range(0, prizeArray.Length);


            float ofsetForPrize = angleOfOnePrize * indexPrizeRandom - startAngle;
            float angleWant = (numberCilrckeRotate * ANGLE_CIRCL) + ofsetForPrize;

            while (currentTimer < timeRotate)
            {
                yield return new WaitForEndOfFrame();
                currentTimer += Time.deltaTime;

                float angleCurrent = (angleWant - startAngle) * curve.Evaluate(currentTimer / timeRotate) + startAngle;
                transform.eulerAngles = new Vector3(0, 0, angleCurrent);
            }
            prizeArray[indexPrizeRandom].OnGetPrize?.Invoke();
            OnGetPrizeUnityEvent.Invoke(prizeArray[indexPrizeRandom]);


        }

        [ContextMenu("Rotate")]
        public void Rotate()
        {

            StartCoroutine(ReotiteWheel());
            OnStartRolling.Invoke();
        }

        //Visual
        [Space(20), Header("Visual")]
        [SerializeField, Range(0, 10)] float scale;
        [SerializeField] private Transform parent;
        [SerializeField] private Color[] coler;
        [SerializeField] private Image circle;
        [SerializeField] private GameObject spaceImage;

        [ContextMenu("MakeSpainVisual")]
        private void MakeSpinVisual()
        {

            float scale = 1 / coler.Length;
            float directOfset = 360 / coler.Length;

            //foreach (Transform item in parent)
            //{
            //    Destroy(item);
            //}

            for (int i = 0; i < coler.Length ; i++)
            {
                Image pice = Instantiate(circle, parent);
                Transform piceTr=pice.transform;

                print(scale);
                pice.fillAmount = scale;

                piceTr.rotation = Quaternion.Euler(0, 0, directOfset * (i + 1));
                piceTr.localPosition=new Vector3(0,0);

            }
        }

    }
}
