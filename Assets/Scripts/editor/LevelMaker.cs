using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;


#if UNITY_EDITOR


public class LevelMaker : EditorWindow
{
    public ChunksList chunks;
    public LevelMakerData data;
    public TextAsset textJson;



    [MenuItem("Window/level maker")]
    public static void ShowWindow()
    {
        LevelMaker l = (LevelMaker)EditorWindow.GetWindow(typeof(LevelMaker), true, "level maker");
        l.Show();
    }

    string notic = "";

    [System.Obsolete]
    private void OnGUI()
    {
        chunks = (ChunksList)EditorGUILayout.ObjectField("chunk list", chunks, typeof(ChunksList));
        data = (LevelMakerData)EditorGUILayout.ObjectField("levels data", data, typeof(LevelMakerData));
        textJson = (TextAsset)EditorGUILayout.ObjectField("text json", textJson, typeof(TextAsset));
        if (GUILayout.Button("make map"))
        {

            string s = MakeLevels();
            notic = "ok \n see the consol for details";
        }
        GUILayout.Label(notic);
    }

    public string MakeLevels()
    {
        List<Level> levels = new List<Level>();
        for (int i = 0; i < data.levelNum; i++)
        {
            levels.Add(makeLevel(i));
        }
        FullLevelData fullLevelData = new FullLevelData(levels.ToArray());
        string json = JsonUtility.ToJson(fullLevelData);

        File.WriteAllText(AssetDatabase.GetAssetPath(textJson), json);

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
        MinMax _hardLevel = new MinMax(hardLevel - data.hardLevelOffset, hardLevel + data.hardLevelOffset);
        //setater
        chunkIndexs.Add(chunks.GetChunk(Chunk.ChunkType.starter, levelNum, _hardLevel));
        //normals
        int chunkNumber = Random.Range(data.levelChunkNumber - data.levelChunkNumberOffset, data.levelChunkNumber + data.levelChunkNumberOffset);
        for (int i = 0; i < chunkNumber; i++)
        {
            chunkIndexs.Add(chunks.GetChunk(chunkType, levelNum, _hardLevel));
        }
        //end level
        chunkIndexs.Add(chunks.GetChunk(Chunk.ChunkType.endLevel, levelNum, _hardLevel));

        Level level = new Level(type, levelNum, chunkIndexs.ToArray());
        return level;
    }

}




#endif