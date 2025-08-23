using UnityEngine;

public class ProbabilityCalculator
{
    public ComponentType ReturnPlatformTypeWithProbability(float LargePlatProb, float MedPlatProb, float SmallPlatProb)
    {
        if (LargePlatProb + MedPlatProb + SmallPlatProb != 100) { MedPlatProb = 100 - LargePlatProb - SmallPlatProb; }

        float roll = Random.Range(0f, 100f);

        if (roll < LargePlatProb) { return ComponentType.LargePlatform; }
        else if (roll < LargePlatProb + MedPlatProb) { return ComponentType.MediumPlatform; }
        else { return ComponentType.SmallPlatform; }
    }

    public ComponentType ReturnWallTypeWithProbability(float LowWallProb, float MidWallProb, float HighWallProb)
    {
        if (HighWallProb + MidWallProb + LowWallProb != 100) { MidWallProb = 100 - HighWallProb - LowWallProb; }

        float roll = Random.Range(0f, 100f);

        if (roll < HighWallProb) { return ComponentType.HighWall; }
        else if (roll < HighWallProb + MidWallProb) { return ComponentType.MidWall; }
        else { return ComponentType.LowWall; }
    }

    public ComponentType ReturnFlowCrystalWithProbability(float BlueProb, float PurpleProb, float PinkProb)
    {
        if (BlueProb + PurpleProb + PinkProb != 100) { BlueProb = 100 - PinkProb - PurpleProb; }

        float roll = Random.Range(0f, 100f);

        if (roll < BlueProb) { return ComponentType.BlueFlowCrystal; }
        else if (roll < BlueProb + PurpleProb) { return ComponentType.PurpleFlowCrystal; }
        else { return ComponentType.PinkFlowCrystal; }
    }

    public bool BuildPlatformWithProbability(float probability)
    {
        if (Random.Range(0f, 100f) < probability)
        {
            return true;
        }
        return false;
    }

    public bool BuildWallWithProbability(float probability)
    {
        if (Random.Range(0f, 100f) < probability)
        {
            return true;
        }
        return false;
    }

    public bool SpawnFlowCrystal(float probability)
    {
        if (Random.Range(0f, 100f) < probability)
        {
            return true;
        }
        return false;
    }
}
