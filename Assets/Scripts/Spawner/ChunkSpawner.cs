using UnityEngine;
using System.Collections.Generic;
public class ChunkSpawner : MonoBehaviour
{
    [SerializeField] private PrefabLibrary library;
    [SerializeField] private Player player;
    [SerializeField] private Transform spawnerParent;

    private ChunkBuilder chunkBuilder;
    private Dictionary<ComponentType, ObjectPool> objectPools;
    private List<Chunk> activeChunks = new List<Chunk>();
    private ChunkComponent prevComponent;

    private Camera cam;
    [SerializeField] private float recycleBuffer = 10f; // distance past chunk end to recycle

    void Start()
    {
        cam = Camera.main;
        InitialiseAllObjectPools();
        chunkBuilder = new ChunkBuilder(2f * cam.orthographicSize * cam.aspect, 2f * cam.orthographicSize, library);

        // Build the start chunk
        Chunk startChunk = chunkBuilder.BuildStartChunk(
            new Vector2(player.transform.position.x, player.transform.position.y - 2f)
        );
        BuildChunkInScene(startChunk);
    }

    void Update()
    {
        float playerX = player.transform.position.x;

        // Spawn next chunk if the player is near the end of the last active chunk
        if (activeChunks.Count > 0)
        {
            Chunk lastChunk = activeChunks[activeChunks.Count - 1];
            if (playerX >= lastChunk.GetStartOfChunk().x)
            {
                Chunk newChunk = chunkBuilder.BuildChunk(lastChunk.GetEndOfChunk(), player, prevComponent, cam);
                BuildChunkInScene(newChunk);
            }
        }

        // Recycle chunks that are far behind the player
        for (int i = 0; i < activeChunks.Count; i++)
        {
            Chunk chunk = activeChunks[i];
            if (playerX >= chunk.GetEndOfChunk().x + recycleBuffer)
            {
                RemoveObjectsFromChunk(chunk);
                activeChunks.RemoveAt(i);
                i--; // adjust loop index
            }
        }
    }

    private void BuildChunkInScene(Chunk chunkToBuild)
    {
        foreach (ChunkComponent component in chunkToBuild.GetComponents())
        {
            GameObject obj = objectPools[component.GetComponentType()].GetFromPool();
            obj.transform.position = component.GetPosition();
            component.SetInstance(obj);
            prevComponent = component;
        }

        activeChunks.Add(chunkToBuild);
    }

    private void RemoveObjectsFromChunk(Chunk chunkToRemove)
    {
        foreach (ChunkComponent component in chunkToRemove.GetComponents())
        {
            GameObject instance = component.GetInstance();
            if (instance != null)
            {
                objectPools[component.GetComponentType()].ReturnToPool(instance);
            }
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

