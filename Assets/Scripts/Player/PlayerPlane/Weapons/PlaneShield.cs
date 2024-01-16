using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlaneShield : MonoBehaviour
{

    [SerializeField] SfxManager sfxManager;
    [SerializeField] float shieldHP;
    [SerializeField] float shieldMaxHP;
    [SerializeField] float coolDown;
    [SerializeField] float shieldDuration;
    [SerializeField] AbilityCooldown AbilityCooldownIcon;

    private float nextShieldTime;

    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polygonCollider2D;

    private bool canCast = false;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        polygonCollider2D = GetComponent<PolygonCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        shieldHP = shieldMaxHP;
        DeActivateShield();
       
    }

    // Update is called once per frame
    void Update()
    {

        if (shieldHP <= 0 )
        {
            DeActivateShield();

        }
        //if ability is off cooldown
        if (Time.time >= nextShieldTime)
        {
            canCast = true;            
        }

       
    }

    private void ActivateShield()
    {
        //Active shield
        sfxManager.PlayShield();
        shieldHP = shieldMaxHP;
        spriteRenderer.enabled = true;
        polygonCollider2D.enabled = true;
        
    }

    private void DeActivateShield()
    {
        spriteRenderer.enabled = false;
        polygonCollider2D.enabled = false;
    }

    private void DeActivateShieldAfterDuration()
    {
        StartCoroutine(ShieldDurationcoroutine());   
    }

    IEnumerator ShieldDurationcoroutine()
    {
        yield return new WaitForSeconds(shieldDuration);
        DeActivateShield();
    }

    public void CastShield()
    {
        if(canCast == true)
        {
            ActivateShield();
            AbilityCooldownIcon.StartAbilityIcon();
            DeActivateShieldAfterDuration();
            nextShieldTime = Time.time + coolDown;
            canCast = false;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyPlaneProjectile enemyPlaneProjectile = collision.GetComponent<EnemyPlaneProjectile>();
        if (enemyPlaneProjectile && player)
        {
            TakeDamage(enemyPlaneProjectile.damage);
            enemyPlaneProjectile.DeActivate(0f);
        }
    }

    public void TakeDamage(float damageTaken)
    {
        shieldHP -= damageTaken;
    }
}
