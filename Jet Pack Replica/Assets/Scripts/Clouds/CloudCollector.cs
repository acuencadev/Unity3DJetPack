using UnityEngine;

public class CloudCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cloud"))
        {
            Destroy(other.gameObject);
        }
    }
}
