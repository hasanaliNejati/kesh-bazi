using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Data;
public class ChunkEditor : MonoBehaviour
{
    public ChunksList chunksList;
    public ObjectList objectList;
    [Space(10)]
    public TextAsset chunkListText;

    //LOGIC
    [HideInInspector] public int currentChunkIndex;
    [HideInInspector] public Chunk currentChunk;
    [HideInInspector] public List<ChunkData> chunks;


}
