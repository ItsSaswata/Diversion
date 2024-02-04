using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    [SerializeField] GameObject destroyVFX;
    [SerializeField] float damageRadius = 5f;
    [SerializeField] int damageAmount = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<DamegeSource>() || other.gameObject.GetComponent<Projectile>())
        {
            Instantiate(destroyVFX, transform.position, Quaternion.identity);
            DamageNearbyEntities();
            Destroy(gameObject);
        }
    }

    private void DamageNearbyEntities()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, damageRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                collider.GetComponent<PlayerHealth>().TakeDamage(10);
            }
            else if (collider.CompareTag("GhostTag"))
            {
                collider.GetComponent<EnemyHealth>().TakeDamage(10);
            }
        }
    }
}
