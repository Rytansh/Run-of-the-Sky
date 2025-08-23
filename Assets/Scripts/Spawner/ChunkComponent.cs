using UnityEngine;

public enum ComponentType
{
    StartPlatform,
    SmallPlatform,
    MediumPlatform,
    LargePlatform,
    LowWall,
    MidWall,
    HighWall,
    BlueFlowCrystal,
    PurpleFlowCrystal,
    PinkFlowCrystal
}
public abstract class ChunkComponent
{
    public Vector2 spawnPosition;
    protected GameObject instance;
    private ComponentType type;
    public bool affectsPlacement;
    public ChunkComponent(ComponentType type, Vector2 spawnPosition, bool affectsPlacement)
    {
        this.spawnPosition = spawnPosition;
        this.type = type;
        this.affectsPlacement = affectsPlacement;
    }

    public Vector2 GetPosition() { return spawnPosition; }
    public bool AffectsPlacement() { return affectsPlacement; }
    public ComponentType GetComponentType() { return type; }
    public void SetInstance(GameObject obj) => instance = obj;
    public GameObject GetInstance() => instance;
}
