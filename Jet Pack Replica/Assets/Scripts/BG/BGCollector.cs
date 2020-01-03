using System.Linq;
using UnityEngine;

public class BGCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BG"))
        {
            RepositionBG(other.gameObject);
        }
    }

    private void RepositionBG(GameObject go)
    {
        var bg = GameObject.FindGameObjectsWithTag("BG").OrderByDescending(t => t.transform.position.x).First();
        var bgCollider = bg.GetComponent<BoxCollider2D>();

        go.transform.position = new Vector3(bg.transform.position.x + bgCollider.bounds.size.x, 0f, 0f);
    }

}
