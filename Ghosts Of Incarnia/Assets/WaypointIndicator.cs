using UnityEngine;

public class WaypointIndicator : MonoBehaviour
{
    public Transform player;
    public Transform spawnPoint;
    public float radius = 5f;
    void Start(){
        if(AssetWarmup.Instance!=null &&AssetWarmup.Instance.centerObject!=null){
            spawnPoint = AssetWarmup.Instance.centerObject.transform;
            player = AssetWarmup.Instance.PlayerPrefab.transform;
        }
    }

    void Update()
    {
        if (player != null && spawnPoint != null)
        {
            // Calculate direction from the player to the spawn point
            Vector3 directionToSpawn = (spawnPoint.position - player.position).normalized;

            // Set the waypoint's position to be around the player
            transform.position = (Vector2)player.position + (Vector2)directionToSpawn * radius;

            // Calculate the angle to rotate the waypoint towards the spawn point
            float angle = Mathf.Atan2(directionToSpawn.y, directionToSpawn.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
        }
    }
}
