using UnityEngine;

public class ChunkBuilder
{
    float chunkWidth, chunkHeight;
    public ChunkBuilder(float chunkWidth, float chunkHeight)
    {
        this.chunkWidth = chunkWidth;
        this.chunkHeight = chunkHeight;
    }
    public Chunk BuildChunk(Vector2 startPosition, Player playerInfo)
    {
        Chunk chunk = new Chunk(startPosition, new Vector2(startPosition.x + chunkWidth, startPosition.y));

        chunk.AddComponentToChunk(new ChunkComponent(ComponentType.LargePlatform, new Vector2(startPosition.x, startPosition.y)));
        chunk.AddComponentToChunk(new ChunkComponent(ComponentType.MediumPlatform, new Vector2(startPosition.x + 5f, startPosition.y)));
        chunk.AddComponentToChunk(new ChunkComponent(ComponentType.SmallPlatform, new Vector2(startPosition.x + 9f, startPosition.y)));

        return chunk;
    }
}
