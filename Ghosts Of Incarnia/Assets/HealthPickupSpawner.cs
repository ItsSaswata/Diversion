using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickupSpawner : MonoBehaviour
{
    [SerializeField] private GameObject HealthPickup;

    public static int totalHealthPickups = 0;  // Updated total number of HealthPickups for all spawners
    public static int healthPickupCount = 0;

    public void DropItem()
    {
        // Check if the total HealthPickups spawned is below the target count
        if (healthPickupCount < totalHealthPickups)
        {
            // Adjust the probability of spawning health pickups (e.g., 75%)
            if (Random.Range(0f, 1f) < 0.75f)
            {
                // Spawn HealthPickup
                Instantiate(HealthPickup, transform.position, Quaternion.identity);
                healthPickupCount++;
            }
        }
    }
}
