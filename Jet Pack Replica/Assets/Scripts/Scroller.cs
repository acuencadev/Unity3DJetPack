using UnityEngine;

public class Scroller : MonoBehaviour
{
    [SerializeField]
    [Range(0f, 10f)]
    private float minSpeed;

    [SerializeField]
    [Range(0f, 10f)]
    private float maxSpeed;

    private float speed;

    private void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
    }

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
