using UnityEngine;

public class SimpleCollector : MonoBehaviour
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
