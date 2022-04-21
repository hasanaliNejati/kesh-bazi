using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{

    public LineRenderer lineRenderer;
    public int count = 50;
    Character _character;
    Character character
    {
        get
        {
            return _character ? _character : _character = GetComponent<Character>();
        }
    }

    void LateUpdate()
    {
        if (character.posControlActive && character.getShootVelocity() != Vector2.zero)
        {
            lineRenderer.positionCount = count;
            lineRenderer.SetPositions(trajectory(character.rb, character.getShootVelocity(), transform.position, count));
        }
        else if(lineRenderer.positionCount > 0)
        {
            lineRenderer.positionCount = 0;
        }
    }

    // this way not working in motion with drag
    //Vector2 getPointPos(Rigidbody2D rb ,Vector2 velocity,float time)
    //{
    //    return (0.5f * rb.gravityScale * Physics2D.gravity * (time * time)) + velocity * time;
    //}

    Vector3[] trajectory(Rigidbody2D rb, Vector2 velocity, Vector2 pos, int steps)
    {
        Vector3[] result = new Vector3[steps];

        float timeStep = Time.fixedDeltaTime / Physics2D.velocityIterations;
        Vector2 gravityAccel = Physics2D.gravity * rb.gravityScale * timeStep * timeStep;
        float drag = 1 - (timeStep * character.freeLinearDrag);

        Vector2 moveStep = velocity * timeStep;
        for (int i = 0; i < steps; i++)
        {
            moveStep += gravityAccel;
            moveStep *= drag;
            pos += moveStep;
            result[i] = pos;
        }

        return result;
    }
}
