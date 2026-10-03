using System.Collections;
using UnityEngine;

public class ImageDeplaceurJsp : MonoBehaviour
{
    public float speed = 0.5f;
    public GameObject monObjet;

    public Vector2 startPosition;
    public Vector2 endPosition;

    void Start()
    {
        StartCoroutine(avancer());
    }

    public IEnumerator avancer()
    {
        startPosition = monObjet.transform.position; // startPosition = transform.position;
        while (Vector2.Distance(monObjet.transform.position, endPosition) > 0.01f)
        {
            monObjet.transform.position = Vector2.MoveTowards(monObjet.transform.position, endPosition, speed * Time.deltaTime);
            yield return null;
        }
    }
}
