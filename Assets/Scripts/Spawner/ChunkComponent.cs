using UnityEngine;

public enum ComponentType
{
    SmallPlatform,
    MediumPlatform,
    LargePlatform,
    SmallWall,
    TallWall

}
public class ChunkComponent
{
    private ComponentType type;
    private Vector2 spawnPosition;
    public ChunkComponent(ComponentType type, Vector2 spawnPosition)
    {
        this.type = type;
        this.spawnPosition = spawnPosition;
    }

    public ComponentType GetComponentType() { return type; }
    public Vector2 GetPosition() { return spawnPosition; }
}
