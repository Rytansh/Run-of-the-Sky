using UnityEngine;
using System.Collections.Generic;
public class Chunk
{
    Vector2 startOfChunk;
    Vector2 endOfChunk;
    List<ChunkComponent> components;

    public Chunk(Vector2 startOfChunk, Vector2 endOfChunk)
    {
        this.startOfChunk = startOfChunk;
        this.endOfChunk = endOfChunk;
        components = new List<ChunkComponent>();
    }

    public void AddComponentToChunk(ChunkComponent component){components.Add(component);}
    public List<ChunkComponent> GetComponents() { return components; }
    public Vector2 GetStartOfChunk() { return startOfChunk; }
    public Vector2 GetEndOfChunk() { return endOfChunk; }
}
