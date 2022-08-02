using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;



[CreateAssetMenu(fileName = "ChunksList", menuName = "ScriptableObjects/ChunksList", order = 1)]
public class ChunksList : ScriptableObject
{

    public Chunk baseChunk;
    [SerializeField]
    public List<ChunkData> chunks = new List<ChunkData>();

    public List<TextAsset> chunksAssets;


    [System.Serializable]
    public struct ListStruct
    {
        public ListStruct(List<ChunkData> data)
        {
            this.data = data;
        }
        public List<ChunkData> data;
    }

    private void Awake()
    {

    }

    public void Import(bool clear = true, int min = 0, int max = 0)
    {
        if (clear)
            chunks.Clear();
        min = max != 0 ? min : 0;
        max = (max > 0 && max < chunksAssets.Count) ? max : chunksAssets.Count;
        Debug.Log("min : " + min);
        Debug.Log("max : " + max);
        for (int i = min; i < max; i++)
        {
            var v = JsonUtility.FromJson<ListStruct>(chunksAssets[i].text);
            chunks.AddRange(v.data);
        }


    }

    public void Import(TextAsset text ,bool clear = true)
    {
        if (clear)
            chunks.Clear();

        var v = JsonUtility.FromJson<ListStruct>(text.text);
        chunks.AddRange(v.data);
    }



    //public List<ChunkData> GetChunksData()
    //{
    //    if (string.IsNullOrEmpty(json))
    //        return new List<ChunkData>();
    //    return JsonUtility.FromJson<List<ChunkData>>(json);
    //}
    //public void SetChunksData(List<ChunkData> chunks)
    //{
    //    json = JsonUtility.ToJson(chunks);
    //}

    public int GetChunk(Chunk.ChunkType type, int level)
    {
        int[] chunkIndexs = GetSpecificChunks(type, level);
        Debug.Log(chunkIndexs.Length + type.ToString());
        int index = Random.Range(0, chunkIndexs.Length);
        return chunkIndexs[index];
    }

    private int[] GetSpecificChunks(Chunk.ChunkType type, int level)
    {
        List<int> chunkIndexs = new List<int>();
        for (int i = 0; i < chunks.Count; i++)
        {
            if (chunks[i].type == type
                && chunks[i].minLevel <= level && chunks[i].maxLevel >= level)
                chunkIndexs.Add(i);
        }
        return chunkIndexs.ToArray();

    }
}
