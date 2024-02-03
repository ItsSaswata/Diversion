using TMPro;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public TextMeshProUGUI collisionText; // Reference to the TextMeshProUGUI for collision display
    private void Start(){
        DisableCollisionText();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spawn")) // Assuming "KeyPrefab" is the tag of your prefab
        {
            EnableCollisionText();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Spawn")) // Assuming "KeyPrefab" is the tag of your prefab
        {
            DisableCollisionText();
        }
    }

    private void EnableCollisionText()
    {
        if (collisionText != null)
        {
            collisionText.gameObject.SetActive(true);
        }
    }
    

    private void DisableCollisionText()
    {
        if (collisionText != null)
        {
            collisionText.gameObject.SetActive(false);
        }
    }
}
