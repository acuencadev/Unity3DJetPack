using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricObstacle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Debug.Log("Player died when collided with a electric obstacle.");
        }
    }
}
