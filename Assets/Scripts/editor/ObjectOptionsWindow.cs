using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class ObjectOptionsWindow : EditorWindow
{

    public static void MakeWindow()
    {
        ObjectOptionsWindow objectOptionsWindow = GetWindow<ObjectOptionsWindow>();
        objectOptionsWindow.Show();
    }

    private void OnGUI()
    {
        try
        {
            if (Selection.objects.Length == 1 && (GameObject)Selection.objects[0])
            {
                var obj = (GameObject)Selection.objects[0];
                if (obj.GetComponent<ObjectGroup>())
                {
                    ResourceGroupEditor(obj.GetComponent<ObjectGroup>());

                }
                else if (true)
                {

                }

                if (obj.GetComponent<ChunkObject>())
                {
                    MovementEditor(obj.GetComponent<ChunkObject>());
                }
            }
        }
        catch
        {
            GUILayout.Label("error");

        }

    }

    private void ResourceGroupEditor(ObjectGroup resourceGroup)
    {
        if (GUILayout.Button("random group"))
        {
            resourceGroup.SellectRandomGroup();
        }
        GUILayout.Space(10);
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("up"))
        {
            resourceGroup.Next();
        }
        if (GUILayout.Button("down"))
        {
            resourceGroup.Back();
        }
        GUILayout.EndHorizontal();
    }

    private void MovementEditor(ChunkObject obj)
    {
        if (obj.movementLine)
        {
            GUILayout.Space(5);
            GUILayout.Label("Movement");
            GUILayout.Space(5);

            if (GUILayout.Button("select Line"))
            {
                Selection.objects = new GameObject[] { obj.movementLine.gameObject };
            }


            if (GUILayout.Button("localization line point"))
            {
                obj.LocalizationLine();
            }
        }
    }
}
