using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

[CustomEditor(typeof(LevelMakerScriptable))]
public class LevelMakerScriptableEditor : Editor
{

    public LevelMakerScriptable data
    {
        get { return (LevelMakerScriptable)target; }
    }
    

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GUILayout.Space(10);

        if (GUILayout.Button("make map"))
        {

            string s = MakeLevels();
            Debug.Log("ok \n see the consol for details");
            Debug.Log(s);
        }


    }

    public string MakeLevels()
    {
        List<Level> levels = new List<Level>();
        data.chunkList.Import(true);
        for (int i = data.minLevel; i <= data.maxLevel; i++)
        {
            levels.Add(makeLevel(i));
        }
        FullLevelData fullLevelData = new FullLevelData(levels.ToArray());
        string json = JsonUtility.ToJson(fullLevelData);

        Export(json);

        return json;
    }

    public Level makeLevel(int levelNum)
    {


        LevelType type = LevelType.normal;
        Chunk.ChunkType chunkType = Chunk.ChunkType.normal;

        if (levelNum % data.fasterLevel == 0 && levelNum > 1)
            type = LevelType.fast;
        else if (levelNum != 1 && ((levelNum - 1) % data.fasterLevel == 0))
        {
            type = LevelType.gift;
            chunkType = Chunk.ChunkType.gift;
        }

        int hardLevel = ((levelNum % data.fasterLevel) / data.fasterLevel) * 10;

        List<int> chunkIndexs = new List<int>();
        //setater
        chunkIndexs.Add(data.chunkList.GetChunk(Chunk.ChunkType.starter, levelNum));
        //normals
        int chunkNumber = Random.Range(data.levelChunkNumber - data.levelChunkNumberOffset, data.levelChunkNumber + data.levelChunkNumberOffset);
        for (int i = 0; i < chunkNumber; i++)
        {
            chunkIndexs.Add(data.chunkList.GetChunk(chunkType, levelNum));
        }
        //end level
        chunkIndexs.Add(data.chunkList.GetChunk(Chunk.ChunkType.endLevel, levelNum));

        Level level = new Level(type, chunkIndexs.ToArray());
        return level;
    }

    private void Export(string text)
    {
        var path = EditorUtility.SaveFilePanel("export level list", UnityEngine.Application.dataPath, "levels " + data.minLevel + " - " + data.maxLevel + ".json", "json");
        if (path.Length != 0)
        {
            Debug.Log(text);
            File.WriteAllText(path, text);
            AssetDatabase.Refresh();
        }
    }

    
}
