using UnityEngine;

public class CameraFollowBehaviour : MonoBehaviour
{
    private float scrollSpeed = 3f;
    private float cameraHalfWidth;

    public float LeftBound => transform.position.x - cameraHalfWidth;
    public float RightBound => transform.position.x + cameraHalfWidth;

    void Start()
    {
        cameraHalfWidth = Camera.main.orthographicSize * Camera.main.aspect;
    }

    void Update()
    {
        transform.position += new Vector3(scrollSpeed * Time.deltaTime, 0, 0);
    }
}