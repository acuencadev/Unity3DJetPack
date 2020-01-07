using System.Linq;
using UnityEngine;

public class SimpleCollector : MonoBehaviour
{
    [SerializeField]
    private string[] matchingTags;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (matchingTags.Contains(other.tag))
        {
            other.gameObject.SetActive(false);
        }
    }
}
