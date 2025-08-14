using UnityEngine;

public class Player : MonoBehaviour
{
    private float playerHeight;
    private float playerWidth;
    private PlayerPhysicsController physicsController;
    private PlayerMovementController movementController;

    void Awake()
    {
        playerWidth = this.transform.localScale.x;
        playerHeight = this.transform.localScale.y;
        physicsController = new PlayerPhysicsController(playerHeight, playerWidth);
        movementController = new PlayerMovementController(physicsController, playerHeight, playerWidth);
    }

    void Update()
    {
        transform.position = movementController.UpdateMovement(transform.position, Input.GetKeyDown(KeyCode.Space));
    }
}
