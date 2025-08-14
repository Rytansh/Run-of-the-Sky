using UnityEngine;

public class PlayerMovementController
{
    private PlayerPhysicsController physicsController;
    private Vector2 velocity;
    private float playerHeight;
    private float playerWidth;

    private float moveSpeed = 3f;
    private float jumpForce = 8f;
    private float gravity = -20f;

    private bool canJump = true;

    public PlayerMovementController(PlayerPhysicsController physics, float playerHeight, float playerWidth)
    {
        physicsController = physics;
        this.playerHeight = playerHeight;
        this.playerWidth = playerWidth;
    }

    public Vector2 UpdateMovement(Vector2 currentPos, bool jumpInput)
    {
        currentPos = MoveWithGravity(currentPos, jumpInput);
        currentPos = MoveForwards(currentPos);

        return currentPos;
    }

    private Vector2 MoveWithGravity(Vector2 currentPos, bool jumpInput)
    {
        bool grounded = physicsController.IsGrounded(currentPos);
        bool collidingUpwards = physicsController.IsCollidingUpwards(currentPos);

        if (grounded)
        {
            velocity.y = 0;
            canJump = true;
            if (jumpInput && canJump)
            {
                velocity.y = jumpForce;
                canJump = false;
            }
        }
        else
        {
            if (collidingUpwards) { velocity.y = 0; }
            velocity.y += gravity * Time.deltaTime;
        }

        currentPos.y += velocity.y * Time.deltaTime;
        if (grounded && velocity.y < 0)
        {
            currentPos.y = Mathf.Round((currentPos.y * 1000f) / 1000f);
            velocity.y = 0;
        }
        return currentPos;
    }
    private Vector2 MoveForwards(Vector2 currentPos)
    {
        bool collidedSideways = physicsController.IsCollidingSideways(currentPos);

        velocity.x = moveSpeed;
        if (collidedSideways) velocity.x = 0;

        currentPos.x += velocity.x * Time.deltaTime;
        return currentPos;
    }
}

