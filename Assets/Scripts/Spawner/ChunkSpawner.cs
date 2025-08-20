using UnityEngine;
using System.Collections.Generic;
public class ChunkSpawner : MonoBehaviour
{
    [SerializeField] PrefabLibrary library;
    [SerializeField] Player player;
    [SerializeField] Transform spawnerParent;

    private ChunkBuilder chunkBuilder;

    private Dictionary<ComponentType, ObjectPool> objectPools;

    void Start()
    {
        InitialiseAllObjectPools();
        chunkBuilder = new ChunkBuilder(15f, 10f);
        Chunk chunkToBuild = chunkBuilder.BuildChunk(new Vector2(player.transform.position.x, player.transform.position.y - 2f), player);
        BuildChunkInScene(chunkToBuild);
    }

    private void BuildChunkInScene(Chunk chunkToBuild)
    {
        foreach (ChunkComponent component in chunkToBuild.GetComponents())
        {
            GameObject obj = objectPools[component.GetComponentType()].GetFromPool();
            obj.transform.position = component.GetPosition();
        }
    }

    private void InitialiseAllObjectPools()
    {
        objectPools = new Dictionary<ComponentType, ObjectPool>();
        foreach (var entry in library.GetPrefabEntries())
        {
            ObjectPool pool = new ObjectPool(entry.prefab, spawnerParent, 10);
            objectPools[entry.type] = pool;
        }
    }
}
