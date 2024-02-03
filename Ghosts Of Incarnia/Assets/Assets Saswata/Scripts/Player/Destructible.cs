using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] GameObject destroyVFX;
    [SerializeField] float explosionForce = 10f;
    [SerializeField] float explosionRadius = 5f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<DamegeSource>() || other.gameObject.GetComponent<Projectile>())
        {
            // Instantiate explosion prefab
            Instantiate(destroyVFX, transform.position, Quaternion.identity);

            // Apply explosion force to nearby objects
            ExplodeObjects();

            // Destroy the destructible object
            Destroy(gameObject);
        }
    }

    private void ExplodeObjects()
    {
        // Get all colliders within the explosion radius
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D collider in colliders)
        {
            // Check if the object has a rigidbody2D
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // Apply explosion force to the object
                Vector2 direction = (rb.transform.position - transform.position).normalized;
                rb.AddForce(direction * explosionForce, ForceMode2D.Impulse);
            }
        }
    }
}
