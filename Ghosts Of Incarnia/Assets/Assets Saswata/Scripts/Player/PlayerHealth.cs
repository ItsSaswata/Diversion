using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : Singleton<PlayerHealth>
{
    public int maxHealth;
    private Slider healthSlider;
    public float knockBackThurst = 10f;
    public float damageRecoveryTime = 1f;
    public int currentHealth;
    bool canTakeDamage = true;
    private KnockBack knockBack;
    private Flash flash;
    EnemyHealth enemyHealth;
    //[SerializeField] private GameObject AISword;

    protected override void Awake(){
        base.Awake();
        flash = GetComponent<Flash>();
        knockBack = GetComponent<KnockBack>();
        enemyHealth = GetComponent<EnemyHealth>();
    }
    private void Start(){
        currentHealth = maxHealth;
        UpdateHealthSlider();

    }
    //private void OnCollisionStay2D(Collision2D other){
    //    EnemyAI enemy = other.gameObject.GetComponent<EnemyAI>();
        //Roamer enemy1 = other.gameObject.GetComponent<Roamer>();
        //ColliderDamage Sword = other.gameObject.GetComponent<ColliderDamage>();
    //    AISword aisword = other.gameObject.GetComponent<AISword>();
    //    Projectile Arrow = other.gameObject.GetComponent<Projectile>();
    //    if((enemy || aisword||Arrow) && canTakeDamage){
    //        TakeDamage(1);
    //        knockBack.GetKnockedBack(other.gameObject.transform,knockBackThurst);
    //        StartCoroutine(flash.FlashRoutine());
    //    }
    //}
    public void HealPlayer(){
        if(currentHealth<maxHealth){
            currentHealth+=10;
           UpdateHealthSlider();
        }
        
    }
    public void TakeDamage(int damageAmt){
        if (ShakeManager.Instance != null)
        {
            ShakeManager.Instance.ShakeScreen();
        }
        canTakeDamage = false;
        currentHealth-=damageAmt;
        StartCoroutine(flash.FlashRoutine());
        //knockBack.GetKnockedBack(enemyHealth.transform,knockBackThurst);
        StartCoroutine(DamageRecoveryRoutine());
        UpdateHealthSlider();
        DetectDeath();
    }
    private IEnumerator DamageRecoveryRoutine(){
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage = true;
    }
    private void DetectDeath(){
        if(currentHealth<=0){
            currentHealth = 0;
            //Destroy(gameObject);
            Debug.Log("Player Died");
        }
    }
    void UpdateHealthSlider(){
        if(healthSlider == null){
            healthSlider= GameObject.Find("HealthSlider").GetComponent<Slider>();
        }
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

}
