using System.Linq;
using UnityEngine;

public class SimpleLooper : MonoBehaviour
{
    [SerializeField]
    private string matchingTag;

    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private Transform parent;

    [SerializeField]
    private int numOfInstances;

    private void Start()
    {
        InstantiatePrefabs();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(matchingTag))
        {
            RepositionPrefab(other.gameObject);
        }
    }

    private void InstantiatePrefabs()
    {
        float currentX = parent.position.x;

        for (var i = 0; i < numOfInstances; i++)
        {
            Vector3 initialPosition = new Vector3(currentX, parent.position.y, parent.position.y);

            GameObject newInstance = Instantiate(prefab, initialPosition, Quaternion.identity, parent);
            BoxCollider2D newInstanceCollider = newInstance.GetComponent<BoxCollider2D>();

            if (newInstanceCollider != null)
            {
                currentX = newInstance.transform.position.x + newInstanceCollider.bounds.size.x;
            }
        }
    }

    private void RepositionPrefab(GameObject go)
    {
        var bg = GameObject.FindGameObjectsWithTag(matchingTag).OrderByDescending(t => t.transform.position.x).First();
        var bgCollider = bg.GetComponent<BoxCollider2D>();

        go.transform.position = new Vector3(bg.transform.position.x + bgCollider.bounds.size.x, parent.position.y, parent.position.y);
    }
}
