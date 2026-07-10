using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private float speed;
    private void Move(Vector2 direction)
    {
        camera.transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
    }

    private void OnEnable()
    {
        InputManager.OnMoveUpdate += Move;
    }

    private void OnDisable()
    {
        InputManager.OnMoveUpdate -= Move;
    }
}