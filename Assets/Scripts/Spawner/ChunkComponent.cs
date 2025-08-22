using UnityEngine;

public enum ComponentType
{
    StartPlatform,
    SmallPlatform,
    MediumPlatform,
    LargePlatform,
    LowWall,
    MidWall,
    HighWall

}
public class ChunkComponent
{
    private ComponentType type;
    private Vector2 spawnPosition;
    private GameObject instance;
    public ChunkComponent(ComponentType type, Vector2 spawnPosition)
    {
        this.type = type;
        this.spawnPosition = spawnPosition;
    }

    public void SetInstance(GameObject obj) => instance = obj;
    public GameObject GetInstance() => instance;

    public ComponentType GetComponentType() { return type; }
    public Vector2 GetPosition() { return spawnPosition; }
}
