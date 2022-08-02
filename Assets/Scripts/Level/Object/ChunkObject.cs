using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;

public class ChunkObject : MonoBehaviour
{
    public LineRenderer movementLine;
    public float moveSpeed = 1;
    public float rotate = 0;
    public bool limitRotate;
    public float rotateSpeed = 10;
    [HideInInspector] public string object_tag = "";
    protected string otherData;

    //LOGIC
    //--Movment
    private int currentMovePoint;
    private int beforMovePoint;
    private float currentRotation;
    private float targetRotation;
    private float startRotation;
    private float endRotation;
    public ObjectData GetData()
    {
        var data = new ObjectData();
        data.object_tag = object_tag;
        data.pos = transform.localPosition;
        data.linePoints = GetLinePoints();
        data.lineLoop = GetLineLoop();
        data.moveSpeed = moveSpeed;
        data.angle = transform.rotation.eulerAngles.z;
        data.rotate = this.rotate;
        data.rotateLoop = limitRotate;
        data.rotateSpeed = rotateSpeed;
        data.otherData_json = otherData;
        return data;
    }

    private void Start()
    {
        startRotation = transform.rotation.eulerAngles.z;
        currentRotation = startRotation;
        endRotation = startRotation + rotate;
        Movment(true);
    }

    private void Update()
    {
        Movment();
        OtherUpdate();
    }

    void Movment(bool forced = false)
    {
        if (movementLine && movementLine.positionCount > 1)
        {
            void nextMovePoint()
            {
                int lineLenght = movementLine.positionCount;
                if (currentMovePoint >= lineLenght - 1)
                {
                    beforMovePoint = currentMovePoint;
                    if (GetLineLoop())
                    {
                        currentMovePoint = 0;
                    }
                    else
                    {
                        currentMovePoint--;
                    }
                    return;
                }
                if (currentMovePoint <= 0)
                {
                    beforMovePoint = currentMovePoint;
                    currentMovePoint++;
                    return;
                }


                if (GetLineLoop())
                {
                    beforMovePoint = currentMovePoint;
                    currentMovePoint++;
                }
                else
                {
                    int offset = currentMovePoint - beforMovePoint;
                    beforMovePoint = currentMovePoint;
                    currentMovePoint += offset;
                }
            }

            if (forced)
            {
                transform.position = movementLine.GetPosition(currentMovePoint);
                nextMovePoint();
            }
            else
            {
                Vector2 targetPos = movementLine.GetPosition(currentMovePoint);
                transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
                if ((Vector2)transform.position == targetPos)
                    nextMovePoint();
            }
        }
        if (rotate != 0 && rotateSpeed != 0)
        {
            if (limitRotate)
            {
                currentRotation = Mathf.MoveTowards(currentRotation, targetRotation, rotateSpeed * Time.deltaTime);
                if (currentRotation == startRotation)
                    targetRotation = endRotation;
                if (currentRotation == endRotation)
                    targetRotation = startRotation;
            }
            else
            {
                if (rotate > 0)
                    currentRotation += rotateSpeed * Time.deltaTime;
                else
                    currentRotation -= rotateSpeed * Time.deltaTime;
            }
            transform.rotation = Quaternion.Euler(0, 0, currentRotation);

        }
    }

    protected virtual void OtherUpdate()
    {

    }

    #region line
    private Vector2[] GetLinePoints()
    {
        if (movementLine)
        {

            Vector3[] points = new Vector3[movementLine.positionCount];
            movementLine.GetPositions(points);
            Vector2[] pointsV2 = new Vector2[points.Length];
            for (int i = 0; i < points.Length; i++)
            {
                pointsV2[i] = points[i] - transform.position;
            }
            return pointsV2;
        }
        return new Vector2[0];
    }
    private bool GetLineLoop()
    {

        if (movementLine)
        {
            return movementLine.loop;
        }
        return false;
    }

    public void SetMovmentLine(Vector2[] data)
    {
        if (!movementLine)
            return;

        movementLine.positionCount = data.Length;
        var dataV3 = new Vector3[data.Length];
        for (int i = 0; i < data.Length; i++)
        {
            dataV3[i] = (Vector3)data[i] + transform.position;
        }
        movementLine.SetPositions(dataV3);
    }

    public void LocalizationLine()
    {
        Vector2 offset = transform.position - movementLine.GetPosition(0);

        Vector3[] localPoints = new Vector3[movementLine.positionCount];
        for (int i = 0; i < movementLine.positionCount; i++)
        {
            localPoints[i] = movementLine.GetPosition(i) + (Vector3)offset;
        }
        movementLine.SetPositions(localPoints);
    }

    public void SetLineLoop(bool loop)
    {
        if (!movementLine)
            return;
        movementLine.loop = loop;
    }
    #endregion
    public virtual void SetOtherData(string data)
    {
        otherData = data;
    }
}
