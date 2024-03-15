using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu()]
public class ChunkPackSO : ScriptableObject
{

    public List<Chunk> Chunks;

    public List<Chunk> GetChunkOfLevel(int level)
    {
        List<Chunk> chunksTarget = new List<Chunk>();

        foreach (Chunk chunk in Chunks)
        {
            if (chunk.minLevle <= level)
            {
                chunksTarget.Add(chunk);
            }
        }
        return chunksTarget;
    }

    public Chunk GetChunkIndex(int index)
    {
        return Chunks[index];
    }




}
