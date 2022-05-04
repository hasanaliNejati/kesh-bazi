using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class Character : MonoBehaviour
{
    [Header("shoting")]
    public float minDistance = 1;
    public float maxDistance = 3;
    public float shootPower = 20;
    //public float smoothSpeed = 5;
    public float rotationSmoothSpeed = 5;

    [Header("elastic")]
    public float elasticPower = 20;
    public float minElasticSize = 1;
    public float maxElasticSize = 3;
    public InputPanel inputPanel;


    [Header("physic")]
    public float freeLinearDrag = 0f;
    public float freeAngularDrag = 0f;
    public float connectLinearDrag = 1;
    public float connectAngularDrag = 8f;
    public Transform centerOfMass;

    [Space(10)]
    [Header("Feedbacks")]
    [SerializeField] private MMFeedbacks defaultShootFeedback;
    [SerializeField] private MMFeedbacks defaultPullFeedback;
    [SerializeField] private MMFeedbacks defaultSpownFeedback;



    Pin beforePin;
    Pin _connectedPin;
    internal Pin connectedPin
    {
        get { return _connectedPin; }
        set
        {
            _connectedPin = value;
            if (_connectedPin != null)
            {
                rb.drag = connectLinearDrag;
                rb.angularDrag = connectAngularDrag;
            }
            else
            {
                rb.drag = freeLinearDrag;
                rb.angularDrag = freeAngularDrag;
            }
        }
    }

    [Space(10)]
    public Transform[] defaultAnchors;



    [Space(10)]
    [Header("cahracter models")]
    public CharacterModel[] characterModels;



    //LOGIC

    internal Transform[] anchors;

    private MMFeedbacks shootFeedback;
    private MMFeedbacks pullFeedback;
    private MMFeedbacks spownFeedback;

    Rigidbody2D _rb;
    internal Rigidbody2D rb
    {
        get
        {
            return _rb ? _rb : _rb = GetComponent<Rigidbody2D>();
        }
    }


    private void Start()
    {
        inputPanel.setEvents(clickDown, clickStay, clickUp);
        if (centerOfMass)
            rb.centerOfMass = centerOfMass.position;

        SetCharacterModelIndex(SaveManager.selectedCharacter, false);
    }

    private void FixedUpdate()
    {
        if (connected)
        {

            //add elastic force
            foreach (Transform t in anchors)
            {
                Vector2 direction = (Vector2)connectedPin.position - (Vector2)t.position;
                float distance = direction.magnitude;

                if (distance > minElasticSize)
                {
                    float force = elasticPower * Mathf.Clamp((distance - minElasticSize), 0, maxElasticSize - minElasticSize);
                    rb.AddForceAtPosition(force * direction.normalized, t.position);
                }

            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Pin pin;
        if (!posControlActive && (pin = collision.GetComponent<Pin>()))
        {
            if (beforePin && pin == beforePin)
            {
                beforePin = null;
            }
            else if (pin != connectedPin)
            {
                connectedPin = pin;

                pin.Connect();
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for (int i = 0; i < anchors.Length; i++)
        {
            Gizmos.DrawSphere(anchors[i].position, 0.1f);
        }
    }

    public bool connected
    {
        get { return connectedPin; }
    }


    #region input

    bool _posControlActive;
    internal bool posControlActive
    {
        get
        {
            return _posControlActive;
        }
        set
        {
            //disable rigidbody
            //rb.bodyType = value?RigidbodyType2D.Kinematic:RigidbodyType2D.Dynamic;

            rb.simulated = !value;

            _posControlActive = value;

        }
    }

    Vector2 startClickPos;

    public void clickDown(Vector2 pos)
    {
        if (connectedPin)
        {
            posControlActive = true;
            startClickPos = pos + Vector2.up;
            pullFeedback?.PlayFeedbacks();
        }
    }

    public void clickStay(Vector2 pos)
    {
        if (posControlActive && connected)
        {
            //screen to world
            Vector3 _pos = pos;
            _pos.z = transform.position.z - Camera.main.transform.position.z;
            pos = (Vector2)Camera.main.ScreenToWorldPoint(_pos);
            //--
            Vector3 _startClickPos = startClickPos;
            _startClickPos.z = transform.position.z - Camera.main.transform.position.z;
            Vector2 direction = pos - (Vector2)Camera.main.ScreenToWorldPoint(_startClickPos);
            float distance = Mathf.Clamp(direction.magnitude, 0, maxDistance);
            direction = direction.normalized;

            transform.position = /*Vector2.Lerp(transform.position, */(direction * distance) + (Vector2)connectedPin.position/*,smoothSpeed * Time.deltaTime)*/;

            transform.rotation = Quaternion.Lerp(transform.rotation, Look2d(transform.position, connectedPin.position), rotationSmoothSpeed);

        }
    }

    public void clickUp(Vector2 pos)
    {
        if (posControlActive)
        {
            posControlActive = false;
            shoot();
        }
    }

    Quaternion Look2d(Vector2 pos, Vector2 distenation)
    {
        Vector2 direction = pos - distenation;
        float z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(0, 0, z + 90);
    }


    void shoot()
    {

        //rb.velocity = Vector2.zero;

        rb.angularVelocity = 0;

        Vector2 shootVelocity = getShootVelocity();
        if (shootVelocity != Vector2.zero)
        {
            rb.velocity = shootVelocity;
            beforePin = connectedPin;
            connectedPin = null;
        }

        pullFeedback?.StopFeedbacks();
        shootFeedback?.PlayFeedbacks();
    }
    internal Vector2 getShootVelocity()
    {
        float distance = shootDirection().magnitude - minDistance;
        if (distance > 0)
        {
            Vector2 direction = shootDirection();
            return direction.normalized * (distance + 0.2f) * shootPower;
        }
        return Vector2.zero;
    }
    Vector2 shootDirection() => connectedPin.position - (Vector2)transform.position;

    #endregion

    #region character model

    public void SetCharacterModelIndex(int index, bool feedback = true)
    {
        DisableAllCharacterModel();

        var customModel = characterModels[index];
        if (customModel.targetCustomIndex > 0)
            customModel = characterModels[customModel.targetCustomIndex];


        //set property
        if (customModel.customAnchor)
            anchors = customModel.anchors;
        else
            anchors = defaultAnchors;

        if (customModel.customFeedback)
        {
            pullFeedback = customModel.pullFeedback ? customModel.pullFeedback : defaultPullFeedback;
            shootFeedback = customModel.shootFeedback ? customModel.shootFeedback : defaultShootFeedback;
            spownFeedback = customModel.spownFeedback ? customModel.spownFeedback : defaultSpownFeedback;

        }
        else
        {
            pullFeedback = defaultPullFeedback;
            shootFeedback = defaultShootFeedback;
            spownFeedback = defaultSpownFeedback;
        }

        characterModels[index].gameObject.SetActive(true);

        if (feedback)
            spownFeedback?.PlayFeedbacks();
    }

    private void DisableAllCharacterModel()
    {
        foreach (var item in characterModels)
        {
            item.gameObject.SetActive(false);
        }
    }

    #endregion 
}
