using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField]
    private string[] compareTags;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (compareTags.Contains(other.tag))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
