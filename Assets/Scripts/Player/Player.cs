using UnityEngine;

public class Player : MonoBehaviour
{
    private float playerHeight;
    private float playerWidth;

    public float jumpForce = 10f;
    private PlayerPhysicsController physicsController;
    private PlayerMovementController movementController;
    private PlayerBoundaryChecker playerBoundaryChecker;
    [SerializeField] public CameraFollowBehaviour cameraFollowBehaviour;

    void Awake()
    {
        playerWidth = this.transform.localScale.x;
        playerHeight = this.transform.localScale.y;
        physicsController = new PlayerPhysicsController(playerHeight, playerWidth);
        movementController = new PlayerMovementController(physicsController, playerHeight, playerWidth);
        playerBoundaryChecker = new PlayerBoundaryChecker(cameraFollowBehaviour);
    }

    void Update()
    {
        transform.position = movementController.UpdateMovement(transform.position, Input.GetKeyDown(KeyCode.Space));
        if (playerBoundaryChecker.CheckBoundaries(this) == PlayerBoundaryChecker.BoundaryResult.ClampNeeded)
        {
            Vector2 clampedPos = new Vector2(cameraFollowBehaviour.RightBound - playerWidth/2, transform.position.y);
            transform.position = movementController.ClampPosition(transform.position, clampedPos);
        }
    }


    public float GetWidth() { return playerWidth; }
    public float GetHeight() { return playerHeight; }
}
