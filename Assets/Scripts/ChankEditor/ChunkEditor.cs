using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
public class ChunkEditor : MonoBehaviour
{
    public ChunksList chunkList;
    public ObjectList objectList;

    //LOGIC
    [HideInInspector] public int currentChunkIndex;
    [HideInInspector] public Chunk currentChunk;
    [HideInInspector] public List<ChunkData> chunks;
}
