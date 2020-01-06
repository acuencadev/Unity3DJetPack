using System.Linq;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private string[] compareTags;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (compareTags.Contains(other.tag))
        {
            Destroy(gameObject);
            Debug.Log("Player died when collided with a electric obstacle.");
        }
    }
}
