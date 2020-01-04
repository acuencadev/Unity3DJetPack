using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SimplePrefabPool : MonoBehaviour
{
    [SerializeField]
    [Range(1, 100)]
    private int poolSize;

    [SerializeField]
    private GameObject[] prefabs;

    private List<GameObject> instances;

    private void Awake()
    {
        instances = new List<GameObject>(poolSize);
    }

    public bool HasItemsAvailable()
    {
        return instances.Count < poolSize || instances.Where(t => !t.activeInHierarchy).Count() > 0;
    }

    public GameObject GetItem(Vector3 position, Quaternion rotation, Transform parent)
    {
        GameObject firstDeactivated = instances.Where(t => !t.activeInHierarchy).FirstOrDefault();

        if (firstDeactivated == null)
        {
            firstDeactivated = InstantiateNewItem(position, rotation, parent);
        }
        else
        {
            firstDeactivated.SetActive(true);
            firstDeactivated.transform.position = position;
            firstDeactivated.transform.rotation = rotation;
        }

        return firstDeactivated;
    }

    private GameObject InstantiateNewItem(Vector3 position, Quaternion rotation, Transform parent)
    {
        int randomIndex = Random.Range(0, prefabs.Length);
        GameObject newInstance = Instantiate(prefabs[randomIndex], position, rotation, parent);

        instances.Add(newInstance);

        return newInstance;
    }
}
