using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(ChunksList))]
public class ChunksList_Editor : Editor
{

    ChunksList chunksList
    {
        get
        {
            return (ChunksList)target;
        }
    }

    //LOGIC
    int minIndexToImport;
    int maxIndexToImport;
    bool clear = true;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GUILayout.Label(chunksList.chunks.Count.ToString());
        if (GUILayout.Button("Export json"))
        {
            Export();
        }


        GUILayout.Space(20);

        GUILayout.BeginHorizontal();

        minIndexToImport = EditorGUILayout.IntField(minIndexToImport);
        maxIndexToImport = EditorGUILayout.IntField(maxIndexToImport);
        if (GUILayout.Button("import"))
            chunksList.Import(true, minIndexToImport, maxIndexToImport);

        GUILayout.EndHorizontal();
    }


    private void Export()
    {
        var path = EditorUtility.SaveFilePanel("export chunk list", UnityEngine.Application.dataPath, "0 - 100.json", "json");
        if (path.Length != 0)
        {
            string json = JsonUtility.ToJson(new ChunksList.ListStruct(chunksList.chunks));
            Debug.Log(json);
            File.WriteAllText(path, json);
            AssetDatabase.Refresh();
        }
    }

    
}
