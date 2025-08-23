using UnityEngine;
using System.Collections.Generic;

public class FlowCrystal : ChunkComponent
{
    private static readonly Dictionary<ComponentType, int> flowCrystalValues = new()
    {
        { ComponentType.BlueFlowCrystal, 1 },
        { ComponentType.PurpleFlowCrystal, 2 },
        { ComponentType.PinkFlowCrystal, 3 }
    };
    private int value;
    public FlowCrystal(ComponentType type, Vector2 pos) : base(type, pos, false)
    {
        value = flowCrystalValues.TryGetValue(type, out var val) ? val : 0;
    }

    public int GetValue() { return value; }
        
}
