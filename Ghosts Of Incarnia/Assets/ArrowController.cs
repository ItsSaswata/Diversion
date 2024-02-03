using UnityEngine;
using UnityEngine.UI;

public class ArrowController : MonoBehaviour
{
    public Transform target; // The target point to which the arrow should point
    public RectTransform canvasRect; // Reference to the Canvas RectTransform
    public float offsetFromEdge = 50f; // Offset from the screen edge
    public Transform player; // Reference to the player's Transform

    void Update()
    {
        if (target != null && player != null)
        {
            // Calculate the direction from the player to the target
            Vector3 direction = target.position - player.position;

            // Calculate the rotation angle based on the direction
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Apply the rotation to the arrow
            transform.rotation = Quaternion.Euler(0f, 0f, angle);

            // Move the arrow to the side of the screen
            Vector3 arrowPosition = GetScreenEdgePosition(angle);
            transform.position = arrowPosition;
        }
    }

    Vector3 GetScreenEdgePosition(float angle)
    {
        // Calculate the position at the edge of the screen based on the angle
        float halfWidth = canvasRect.sizeDelta.x / 2f;
        float halfHeight = canvasRect.sizeDelta.y / 2f;

        float angleRad = angle * Mathf.Deg2Rad;
        float x = Mathf.Cos(angleRad) * halfWidth;
        float y = Mathf.Sin(angleRad) * halfHeight;

        // Apply the offset from the screen edge
        x = Mathf.Clamp(x, -halfWidth + offsetFromEdge, halfWidth - offsetFromEdge);
        y = Mathf.Clamp(y, -halfHeight + offsetFromEdge, halfHeight - offsetFromEdge);

        // Convert to world coordinates
        Vector3 screenEdgePos = new Vector3(x, y, 0f);
        return Camera.main.ScreenToWorldPoint(canvasRect.position + screenEdgePos);
    }
}
