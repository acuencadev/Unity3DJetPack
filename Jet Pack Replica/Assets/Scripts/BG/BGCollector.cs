using System.Linq;
using UnityEngine;

public class BGCollector : MonoBehaviour
{
    [SerializeField]
    private GameObject backgroundPrefab;

    [SerializeField]
    private Transform parent;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BG"))
        {
            Destroy(other.gameObject);
            InstantiateNewBG();
        }
    }

    private Vector3 GetLastBgPosition()
    {
        var bg = GameObject.FindGameObjectsWithTag("BG").OrderByDescending(t => t.transform.position.x).First();
        var bgCollider = bg.GetComponent<BoxCollider2D>();

        return (bgCollider == null) ? Vector3.zero : new Vector3(bg.transform.position.x + bgCollider.bounds.size.x, 0f, 0f);
    }

    private void InstantiateNewBG()
    {
        GameObject newInstance = Instantiate(backgroundPrefab, GetLastBgPosition(), Quaternion.identity, parent);
    }
}
