using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject HealthPickup;
    [SerializeField] private GameObject KeyPickup;
    

    private int totalKeyPickups = 10; // Total number of KeyPickups
    private int keyPickupCount = 0;
    
    public void DropItems()
    {
        if (keyPickupCount < totalKeyPickups && Random.Range(0f, 1f) < 0.2f)
        {
            // Spawn KeyPickup with a lower probability (0.2)
            Instantiate(KeyPickup, transform.position, Quaternion.identity);
            keyPickupCount++;
        }
        else
        {
            // Spawn HealthPickup with a higher probability (0.8)
            Instantiate(HealthPickup,transform.position, Quaternion.identity);
        }
    }

    
}
