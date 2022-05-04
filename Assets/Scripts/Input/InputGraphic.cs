using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputGraphic : MonoBehaviour
{
    [SerializeField] private LineRenderer line;
    [SerializeField] private Vector2 dragMinMax = new Vector2(1, 4);
    [SerializeField] private Animator animator;
    [SerializeField] private string startAnimation = "start";
    [SerializeField] private string endAnimation = "end";
    //LOGIC
    private Vector2 startClickLocalPos;
    private Character _character;
    private Character character
    {
        get
        {
            return _character ? _character : _character = FindObjectOfType<Character>();
        }
    }
    private bool enabledGraphic;

    private void Start()
    {
        var inputPanel = FindObjectOfType<InputPanel>();

        inputPanel.setEvents(Down, Stay, Up);


    }

    public void Down(Vector2 pos)
    {
        if (!character.connected)
            return;

        startClickLocalPos = Camera.main.ScreenToWorldPoint(pos) - Camera.main.transform.position;
        animator.Play(startAnimation);
        enabledGraphic = true;
    }

    public void Stay(Vector2 pos)
    {
        var points = new Vector3[2];

        var startClickPos = startClickLocalPos + (Vector2)Camera.main.transform.position;
        var courrentPos = (Vector2)Camera.main.ScreenToWorldPoint(pos);
        var direction = courrentPos - startClickPos;
        float distance = Mathf.Clamp(direction.magnitude, dragMinMax.x, dragMinMax.y);
        var newPos = startClickPos + (direction.normalized * distance);

        points[0] = startClickPos;
        points[1] = newPos;

        line.SetPositions(points);
    }

    public void Up(Vector2 pos)
    {
        if (!enabledGraphic)
            return;
        animator.Play(endAnimation);
        enabledGraphic = false;
    }

}
