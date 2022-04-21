using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Data;
public class LevelManager : MonoBehaviour
{

    public ChunksList chunksList;
    public ObjectList objectList;
    public TextAsset text;

    public LevelType currentLevelType;

    // Start is called before the first frame update
    void Awake()
    {
        instantiatLevel(JsonUtility.FromJson<FullLevelData>(text.text).levels[SaveManager.level]);
    }

    internal float height = 0;
    public void instantiatLevel(Level level)
    {
        currentLevelType = level.type;
        if (level.type == LevelType.fast)
        {
            FindObjectOfType<CameraFollow>().fasterMod = true;
            
        }
        for (int i = 0; i < level.chunkIndexs.Length; i++)
        {
            ChunkData data = chunksList.chunks[level.chunkIndexs[i]];
            var chunk = Instantiate(chunksList.baseChunk, new Vector3(0, height, 0), new Quaternion());
            chunk.GenerateChunk(data, objectList);
            height += data.height;
        }
    }
}
