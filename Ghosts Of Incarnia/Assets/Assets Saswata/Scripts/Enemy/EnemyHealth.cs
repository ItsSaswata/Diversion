using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
//gg
public class EnemyHealth : MonoBehaviour
{
    [SerializeField]int StartingHealth = 3;
    [SerializeField]GameObject deathVFXPrefab;
    [SerializeField]float knockBackThurst = 15f;
    KnockBack knockBack;
    
    Flash flash;
    int currentHealth;
    private void Awake(){
        flash = GetComponent<Flash>();
        knockBack = GetComponent<KnockBack>();
    }
    private void Start(){
        currentHealth = StartingHealth;
    }
    public void TakeDamage(int damage){
        currentHealth-=damage;
        knockBack.GetKnockedBack(PlayerController.Instance.transform,knockBackThurst);
        StartCoroutine(flash.FlashRoutine());
        StartCoroutine(CheckDetectDeathCoroutine());
    }
    private IEnumerator CheckDetectDeathCoroutine(){
        yield return new WaitForSeconds(flash.GetRestoreMatTime());
        DetectDeath();
    }
    public void DetectDeath(){
        if(currentHealth<=0){
            Instantiate(deathVFXPrefab,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
