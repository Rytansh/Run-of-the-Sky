using UnityEngine;

public class PlayerPhysicsController
{
    private LayerMask groundMask;
    private float groundCheckDistance;
    private CollisionDetector collisionDetector;

    public PlayerPhysicsController(float playerHeight, float playerWidth)
    {
        this.groundMask = LayerMask.GetMask("Ground");
        this.groundCheckDistance = 0.05f;
        collisionDetector = new CollisionDetector(playerHeight, playerWidth);
    }

    public bool IsGrounded(Vector2 playerPosition)
    {
        return collisionDetector.IsGrounded(playerPosition, groundCheckDistance, groundMask);
    }
    public bool IsCollidingSideways(Vector2 playerPosition)
    {
        return collisionDetector.IsCollidingSideways(playerPosition, groundCheckDistance, groundMask);
    }

    public bool IsCollidingUpwards(Vector2 playerPosition)
    {
        return collisionDetector.IsCollidingUpwards(playerPosition, groundCheckDistance, groundMask);
    }
}
