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

        if (Selection.objects.Length == 1)
        {
            var obj = (GameObject)Selection.objects[0];
            if (obj.GetComponent<ResourceGroup>())
            {
                ResourceGroupEditor(obj.GetComponent<ResourceGroup>());

            }else if (true)
            {

            }
        }

    }

    private void ResourceGroupEditor(ResourceGroup resourceGroup)
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
}
