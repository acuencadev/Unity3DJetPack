using UnityEngine;

public class BGSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject backgroundPrefab;

    [SerializeField]
    private Transform parent;

    [SerializeField]
    private int numOfInstances;

    private void Start()
    {
        InstantiateBackgrounds();
    }

    private void InstantiateBackgrounds()
    {
        float currentX = transform.position.x;

        for (var i = 0; i < numOfInstances; i++)
        {
            Vector3 initialPosition = new Vector3(currentX, 0f, 0f);

            GameObject newInstance = Instantiate(backgroundPrefab, initialPosition, Quaternion.identity, parent);
            BoxCollider2D newInstanceCollider = newInstance.GetComponent<BoxCollider2D>();

            if (newInstanceCollider != null)
            {
                currentX = newInstance.transform.position.x + newInstanceCollider.bounds.size.x;
            }
        }
    }
}
