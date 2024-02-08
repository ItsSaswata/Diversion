using UnityEngine;

public class DisablePlayerPrefab : MonoBehaviour
{
    void Awake()
    {
        // Find the player prefab in the scene
        GameObject playerPrefab = GameObject.FindGameObjectWithTag("Player");

        // Disable the player prefab if it exists
        if (playerPrefab != null)
        {
            playerPrefab.SetActive(false);
        }
    }
}
