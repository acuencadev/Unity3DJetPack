using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField]
    private string matchingTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(matchingTag))
        {
            other.gameObject.SetActive(false);
        }
    }
}
