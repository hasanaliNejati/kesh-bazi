using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.UIElements;
using System;

[CustomEditor(typeof(ChunkEditor))]
public class ChunkEditor_Editor : Editor
{


    //EDITOR
    string chunkIndexInput;
    string selectError;

    //LOGIC
    ChunkEditor editor
    {
        get
        {
            return (ChunkEditor)target;
        }
    }
    int CurrentChunkIndex
    {
        get
        {
            return editor.currentChunkIndex;
        }
        set
        {
            editor.currentChunkIndex = value;
        }
    }
    Chunk currentChunk
    {
        get
        {
            return editor.currentChunk;
        }
        set
        {
            editor.currentChunk = value;
        }
    }



    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        #region style
        GUIStyleState titleStyle = new GUIStyleState();

        #endregion

        GUILayout.Space(10);

        #region current chunk data

        if (currentChunk != null)
        {
            GUILayout.Label("index : " + CurrentChunkIndex);
            //type
            GUILayout.BeginHorizontal();
            GUILayout.Label("type : " + currentChunk.type);
            currentChunk.type = (Chunk.ChunkType)EditorGUILayout.EnumPopup(currentChunk.type);
            GUILayout.EndHorizontal();

            //height
            GUILayout.BeginHorizontal();
            GUILayout.Label("height : " + currentChunk.height);
            currentChunk.height = EditorGUILayout.FloatField(currentChunk.height);
            GUILayout.EndHorizontal();

            //level
            //      min
            GUILayout.BeginHorizontal();
            GUILayout.Label("Min level : " + currentChunk.minLevel);
            currentChunk.minLevel = EditorGUILayout.IntField(currentChunk.minLevel);
            GUILayout.EndHorizontal();
            //      max
            GUILayout.BeginHorizontal();
            GUILayout.Label("Max level : " + currentChunk.maxLevel);
            currentChunk.maxLevel = EditorGUILayout.IntField(currentChunk.maxLevel);
            GUILayout.EndHorizontal();

            //hard level
            GUILayout.BeginHorizontal();
            GUILayout.Label("hard : " + currentChunk.hardLevel);
            currentChunk.hardLevel = EditorGUILayout.IntSlider(currentChunk.hardLevel, 0, 10);
            GUILayout.EndHorizontal();

        }
        else
        {
            GUILayout.Label("index : ");
            GUILayout.Label("type : - ");
            GUILayout.Label("height : - ");
            GUILayout.Label("level : - ");
            GUILayout.Label("hard : - ");
        }

        #endregion

        GUILayout.Space(10);

        #region select
        GUILayout.Label("Select");
        GUILayout.BeginHorizontal();
        chunkIndexInput = GUILayout.TextField(chunkIndexInput);
        if (GUILayout.Button("select"))
        {

            selectError = "";
            int index = 0;
            if (int.TryParse(chunkIndexInput, out index))
            {
                SelectChunk(index);
            }
            else
                selectError = "input not valid";
        }
        if (GUILayout.Button("unselect + save"))
        {

            if (currentChunk)
            {
                ExitChunk(currentChunk, CurrentChunkIndex);
            }
        }
        GUILayout.EndHorizontal();
        GUILayout.Label(selectError);
        #endregion

        GUILayout.Space(10);

        #region options

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("Up"))
            MoveUp();
        if (GUILayout.Button("Down"))
            MoveDown();
        GUILayout.EndHorizontal();

        GUILayout.Space(5);

        if (GUILayout.Button("duplicate"))
            Duplicate();

        GUILayout.Space(10);

        if (GUILayout.Button("delete"))
        {
            if (currentChunk != null)
            {
                DeleteChunk();
            }
            else
            {
                Debug.LogError("chunk not found!");
            }
        }
        #endregion

        GUILayout.Space(10);

        #region generate new chunk

        GUILayout.Label("generate");

        if (GUILayout.Button("create new chunk"))
        {
            GenerateNewChunk();
        }

        #endregion

        GUILayout.Space(10);

        #region windows

        GUILayout.Label("Windows");
        GUILayout.BeginHorizontal();
        if (GUILayout.Button("object maker"))
        {
            ObjectMakerWindow.MakeWindow(editor);
        }
        GUILayout.EndHorizontal();

        #endregion
    }

    // select and save
    private void SelectChunk(int index)
    {
        //validation
        if (index < 0 || editor.chunkList.chunks.Count <= index)
        {
            Debug.LogError("out of range");
            return;
        }

        //exit corrent chunk
        if (currentChunk != null)
            ExitChunk(currentChunk, CurrentChunkIndex);

        //generate new chunk
        currentChunk = Instantiate(editor.chunkList.baseChunk, Vector3.zero, new Quaternion());
        currentChunk.GenerateChunk(editor.chunkList.chunks[index], editor.objectList);

        CurrentChunkIndex = index;
    }
    private void GenerateNewChunk(ChunkData data = null)
    {
        if (data == null)
            data = new ChunkData();
        editor.chunkList.chunks.Add(data);
        SelectChunk(editor.chunkList.chunks.Count - 1);
    }

    private void MoveUp()
    {
        SelectChunk(CurrentChunkIndex + 1);
    }
    private void MoveDown()
    {
        SelectChunk(CurrentChunkIndex - 1);
    }

    private void Duplicate()
    {
        if (currentChunk)
            GenerateNewChunk(currentChunk.GetData());
    }

    private void DeleteChunk()
    {
        ExitChunk(currentChunk);
        editor.chunkList.chunks.RemoveAt(CurrentChunkIndex);
    }

    private void Save(Chunk chunk, int index)
    {
        //save
        editor.chunkList.chunks[index] = chunk.GetData();
    }
    private void ExitChunk(Chunk chunk, int index = -1)
    {
        //save
        if (index >= 0 && editor.chunkList.chunks.Count > index)
            Save(currentChunk, index);
        //exit
        DestroyImmediate(chunk.gameObject);
        
    }
}
