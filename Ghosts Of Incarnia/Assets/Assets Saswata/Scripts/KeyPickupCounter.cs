using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeyPickupCounter : MonoBehaviour
{
    public static KeyPickupCounter Instance;
    public TextMeshProUGUI keyPickupText;
    private int keyPickupCount = 0;
    private void Awake(){
        Instance = this;
    }
    public void IncrementKeyPickupCount()
    {
        keyPickupCount++;
        UpdateKeyPickupText();
    }

    private void UpdateKeyPickupText()
    {
        if (keyPickupText != null)
        {
            keyPickupText.text = keyPickupCount.ToString();
        }
    }
}
