using UnityEngine;

public class ChunkBuilder
{
    float chunkWidth, chunkHeight;
    ProbabilityCalculator probabilityCalculator;
    PrefabLibrary library;
    public ChunkBuilder(float chunkWidth, float chunkHeight, PrefabLibrary library)
    {
        this.chunkWidth = chunkWidth;
        this.chunkHeight = chunkHeight;
        probabilityCalculator = new ProbabilityCalculator();
        this.library = library;
    }
    public Chunk BuildStartChunk(Vector2 startPosition)
    {
        Chunk chunk = new Chunk(startPosition, new Vector2(startPosition.x + chunkWidth, startPosition.y));
        chunk.AddComponentToChunk(new ChunkComponent(ComponentType.StartPlatform, startPosition));
        chunk.AddComponentToChunk(new ChunkComponent(ComponentType.SmallPlatform, new Vector2(startPosition.x + 4f, startPosition.y + 1f)));
        chunk.AddComponentToChunk(new ChunkComponent(ComponentType.LargePlatform, new Vector2(startPosition.x + 4f, startPosition.y - 1f)));
        chunk.AddComponentToChunk(new ChunkComponent(ComponentType.LargePlatform, new Vector2(startPosition.x + 8f, startPosition.y + 3f)));
        chunk.AddComponentToChunk(new ChunkComponent(ComponentType.MediumPlatform, new Vector2(startPosition.x + 10f, startPosition.y + 4f)));
        chunk.AddComponentToChunk(new ChunkComponent(ComponentType.LowWall, new Vector2(startPosition.x + 10f, -3f)));
        chunk.AddComponentToChunk(new ChunkComponent(ComponentType.MediumPlatform, new Vector2(startPosition.x + 13f, startPosition.y)));
        return chunk;
    }
    public Chunk BuildChunk(Vector2 startPosition, Player playerInfo, ChunkComponent previousComponent, Camera cam)
    {
        Chunk chunk = new Chunk(startPosition, new Vector2(startPosition.x + chunkWidth, startPosition.y));

        float builderXPosition = startPosition.x;

        ChunkComponent lastComponent = previousComponent;

        while (builderXPosition < startPosition.x + chunkWidth)
        {
            ComponentType platformType = probabilityCalculator.ReturnPlatformTypeWithProbability(50, 30, 20);

            Vector2 size = library.GetPrefabFromComponentType(platformType).GetComponent<BoxCollider2D>().size;

            Vector2 pos = GetNextPlatformPosition(lastComponent, size, playerInfo, cam);

            ChunkComponent newComponent = new ChunkComponent(platformType, pos);
            chunk.AddComponentToChunk(newComponent);

            builderXPosition = pos.x + size.x * 0.5f;  

            lastComponent = newComponent;
        }

        return chunk;
    }

    private Vector2 GetNextPlatformPosition(ChunkComponent previous, Vector2 size, Player playerInfo, Camera cam)
    {
        Vector2 prevSize = library.GetPrefabFromComponentType(previous.GetComponentType()).GetComponent<BoxCollider2D>().size;
        float minY = cam.transform.position.y - chunkHeight / 2 + 1f; 
        float maxY = cam.transform.position.y + chunkHeight / 2 - 1f; 


        float gap = Random.Range(1f, 3f); 
        float nextX = previous.GetPosition().x + prevSize.x / 2 + gap + size.x;

        float maxJump = Random.Range(1f, 2f);
        float nextY = previous.GetPosition().y + Random.Range(-maxJump, maxJump);
        nextY = Mathf.Clamp(nextY, minY, maxY);

        return new Vector2(nextX, nextY);
    }

    
}
