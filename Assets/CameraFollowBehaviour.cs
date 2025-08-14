using UnityEngine;

public class CameraFollowBehaviour : MonoBehaviour
{
    [SerializeField] private Transform target;       
    private Vector2 offset = new Vector2(2f, 1f); 
    public float smoothSpeed = 10f; // How quickly the camera catches up

    void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
    }
}