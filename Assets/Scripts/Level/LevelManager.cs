using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using Random = UnityEngine.Random;
using static Cinemachine.DocumentationSortingAttribute;

public enum LevelType
{
    normal, fast, gift
}

public class LevelManager : MonoBehaviour
{


    public LevelType currentLevelType;



    [SerializeField] private ChunkPackSO normalChunks;
    [SerializeField] private ChunkPackSO fastChunks;
    [SerializeField] private ChunkPackSO giftChunks;
    [SerializeField] private Pin endPoint;


    [SerializeField] private int fastNumber;


    [Space(20), SerializeField] private int minNumberChunk, maxNumberChunk;
    public List<int> levels = new List<int>();

    private void Start()
    {
        currentLevelType = GetLevelType(SaveManager.level);
        LoadLevelData();
        InstantiatLevel();

        if (currentLevelType == LevelType.fast)
        {
            CameraFollow.Instans.fasterMod = true;
        }
        else
        {
            CameraFollow.Instans.fasterMod = false;
        }

        MainManager.Instans.OnWin += Win;
        print(GetLevelType(SaveManager.level).ToString());
    }

    private void Win()
    {
        MakeLevel(SaveManager.level);
    }

    internal float height = 0;
    public void InstantiatLevel()
    {
        List<Chunk> chunks = new List<Chunk>();
        switch (GetLevelType(SaveManager.level))
        {
            case LevelType.normal:
                chunks = normalChunks.Chunks;
                break;
            case LevelType.fast:
                chunks = fastChunks.Chunks;
                break;
            case LevelType.gift:
                chunks = giftChunks.Chunks;
                break;

        }

        foreach (var level in levels)
        {
            Chunk chunk = Instantiate(chunks[level]);
            chunk.transform.position = new Vector3(0, height);
            height += chunk.height;
        }
        endPoint.transform.position = new Vector3(0, height + 2);

    }


    private void MakeLevel(int level)
    {
        List<Chunk> chunksBas = new List<Chunk>();
        List<Chunk> chunksTarget = new List<Chunk>();
        switch (GetLevelType(level))
        {
            case LevelType.normal:
                chunksBas = normalChunks.Chunks;
                chunksTarget = normalChunks.GetChunkOfLevel(level);
                break;
            case LevelType.fast:
                chunksBas = fastChunks.Chunks;
                chunksTarget = fastChunks.GetChunkOfLevel(level);
                break;
            case LevelType.gift:
                chunksBas = giftChunks.Chunks;
                chunksTarget = giftChunks.GetChunkOfLevel(level);
                break;

        }


        int numberChunk = Random.Range(minNumberChunk, maxNumberChunk);

        Chunk chunk = chunksTarget[Random.Range(0, chunksTarget.Count)];


        levels.Clear();
        for (int i = 0; i < numberChunk; i++)
        {
            print(chunksBas.FindIndex(x => x == chunk));
            levels.Add(chunksBas.FindIndex(x => x == chunk));
        }

        SaveLavelData(levels);
    }



    private LevelType GetLevelType(int level)
    {
        int remaning = level % fastNumber;
        if (remaning == 0 && level != 0)
        {
            return LevelType.fast;
        }
        else if (remaning == 1 && level != 1)
        {

            return LevelType.gift;
        }
        else
        {
            return LevelType.normal;
        }

    }

    private const string KEY_LAVELDATA = "LAVEL_DATA";
    private void SaveLavelData(List<int> leveldata)
    {
        string list = "";
        int i = 0;
        foreach (int level in leveldata)
        {

            list += level;

            if (i != leveldata.Count - 1)
                list += ",";

            i++;
        }
        PlayerPrefs.SetString(KEY_LAVELDATA, list);

    }

    private void LoadLevelData()
    {


        string loadLevel = PlayerPrefs.GetString(KEY_LAVELDATA);
        levels.Clear();
        if (!string.IsNullOrEmpty(loadLevel))
        {
            //print("load");
            string[] data = loadLevel.Split(",");

            foreach (string level in data)
            {
                print(loadLevel);
                levels.Add(Convert.ToInt32(level));
            }

        }
        else
        {
            //print("making");
            MakeLevel(SaveManager.level);
        }

    }

}