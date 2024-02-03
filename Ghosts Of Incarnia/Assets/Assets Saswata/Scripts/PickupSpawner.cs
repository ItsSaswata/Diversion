using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    [SerializeField]private GameObject HealthPickup;
    public void DropItems(){
        Instantiate(HealthPickup,transform.position,Quaternion.identity);
    }    
}
