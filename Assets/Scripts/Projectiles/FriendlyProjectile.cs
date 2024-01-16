using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyProjectile : BasicProjectile
{
    private SfxManager sfxManager;
    // Start is called before the first frame update
    protected override void Start()
    {
        sfxManager = GameObject.FindObjectOfType<SfxManager>();
        base.Start();
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
     
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MapBorders"))
        {
            DeActivate(0);
        }

        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            //sfxManager.PlayEnemyHit();
            enemy.TakeDamage(damage);

            DeActivate(0);
            enemy.HitMarkerFuntion();
            
        }

        Asteroids asteroids = collision.gameObject.GetComponent<Asteroids>();
        if (asteroids)
        {
            asteroids.TakeDamage(damage);
            DeActivate(0);
        }
       
    }

    
}
