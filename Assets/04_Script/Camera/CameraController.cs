using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private float speed;
    [SerializeField] private float edgeZone;
    [SerializeField] private float boostMultiplier;
    private void Move(Vector2 direction)
    {
        camera.transform.position += new Vector3(direction.x, direction.y, 0) * speed * Time.deltaTime;
    }

    private void EdgeMovement(Vector2 mousePosition)
    {
        if (!new Rect(0f, 0f, Screen.width, Screen.height).Contains(mousePosition)) return;
    
        Vector3 newPosition = camera.transform.position;
        if (mousePosition.x <= edgeZone)
        {
            float multiplier = Mathf.InverseLerp(edgeZone, 0, mousePosition.x);
            newPosition.x -= speed * multiplier * boostMultiplier * Time.deltaTime;
        }
        else if (mousePosition.x >= Screen.width - edgeZone)
        {
            float multiplier = Mathf.InverseLerp(Screen.width - edgeZone, Screen.width, mousePosition.x);
            newPosition.x += speed * multiplier * boostMultiplier * Time.deltaTime;
        }
        if (mousePosition.y <= edgeZone)
        {
            float multiplier = Mathf.InverseLerp(edgeZone, 0, mousePosition.y);
            newPosition.y -= speed * multiplier * boostMultiplier * Time.deltaTime;
        }
        else if (mousePosition.y >= Screen.height - edgeZone)
        {
            float multiplier = Mathf.InverseLerp(Screen.height - edgeZone, Screen.height, mousePosition.y);
            newPosition.y += speed * multiplier * boostMultiplier * Time.deltaTime;
        }
        camera.transform.position = newPosition;
    }

    private void OnEnable()
    {
        InputManager.OnMoveUpdate += Move;
        InputManager.OnMouseScreenUpdate += EdgeMovement;
    }

    private void OnDisable()
    {
        InputManager.OnMoveUpdate -= Move;
        InputManager.OnMouseScreenUpdate -= EdgeMovement;
    }
}
