using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private float speed;
    private void Move(Vector2 direction)
    {
        Vector3 moveDirection = camera.transform.position + new Vector3(direction.x, 0, direction.y) * speed * Time.deltaTime;
    }
}
