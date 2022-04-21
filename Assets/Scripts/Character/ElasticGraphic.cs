using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class ElasticGraphic : MonoBehaviour
{

    public Line line;

    public List<Line> lins = new List<Line>();

    Character _character;
    Character character
    {
        get
        {
            return _character ? _character : _character = GetComponent<Character>();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        makeLines();
    }

    void makeLines()
    {
        for (int i = 0; i < character.anchors.Length; i++)
            lins.Add(Instantiate(line, transform));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (character.connected)
        {
            for (int i = 0; i < lins.Count; i++)
            {
                Vector3[] points = new Vector3[2];
                points[0] = character.anchors[i].position;
                points[1] = character.connectedPin.position;
                lins[i].setPoint(points);
            }
        }
        else
        {
            for (int i = 0; i < lins.Count; i++)
                lins[i].setPoint(new Vector3[0]);
        }
    }
}
