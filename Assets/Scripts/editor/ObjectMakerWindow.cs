using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class ObjectMakerWindow : EditorWindow
{
    private ChunkEditor editor;

    public static void MakeWindow(ChunkEditor editor)
    {

        ObjectMakerWindow objectMakerWindow = GetWindow<ObjectMakerWindow>();
        objectMakerWindow.Show();
        objectMakerWindow.editor = editor;
    }

    private void OnEnable()
    {

    }

    private void OnGUI()
    {
        if (!editor)
        {
            GUILayout.Label("editor not found!");
            return;
        }
        List<ObjectList.Obj> objects = editor.objectList.objs;
        for (int i = 0; i < editor.objectList.objs.Count; i++)
        {
            if (GUILayout.Button(objects[i].tag))
            {
                if (editor.currentChunk)
                {
                   ChunkObject newObj = Instantiate(objects[i].chunkObject,Vector3.zero,new Quaternion(), editor.currentChunk.transform);
                    newObj.object_tag = objects[i].tag;
                    Selection.objects = new GameObject[] { newObj.gameObject };
                }
            }
        }

    }
}
