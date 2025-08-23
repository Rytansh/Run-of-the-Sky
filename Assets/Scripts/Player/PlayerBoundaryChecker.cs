using UnityEngine;

public class PlayerBoundaryChecker
{
    public enum BoundaryResult
    {
        None,
        ClampNeeded,
        Fallen
    }
    private CameraFollowBehaviour followBehaviour;
    public PlayerBoundaryChecker(CameraFollowBehaviour followBehaviour)
    {
        this.followBehaviour = followBehaviour;
    }
    public BoundaryResult CheckBoundaries(Player player)
    {
        if (player.transform.position.x + player.GetWidth()/2 > followBehaviour.RightBound)
        {
            return BoundaryResult.ClampNeeded;
        }

        if (player.transform.position.x < followBehaviour.LeftBound)
        {
            return BoundaryResult.Fallen;
        }

        if (player.transform.position.y < -5f)
        {
            return BoundaryResult.Fallen;
        }

        return BoundaryResult.None;
    }
}

