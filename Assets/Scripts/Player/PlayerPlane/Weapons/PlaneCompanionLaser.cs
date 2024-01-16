using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEngine;

public class PlaneCompanionLaser : FriendlyProjectile
{
    private bool isEnemyInBorder = false;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void ProjectileMoving()
    {
        GameObject enemy = FindClosestEnemy();
        if (enemy)
        {
            CheckIfEnemyIsInBorder(enemy);
        }

        if (enemy != null && isEnemyInBorder == true)
        {
            Vector2 direction = (enemy.transform.position - transform.position).normalized;
            this.rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
        }
        else
        {
            transform.position += new Vector3(0, directionY, 0) * speed * Time.deltaTime;
        }
        
 
    }
    
    private GameObject FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        GameObject closestEnemy = null;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject currentEnemy in enemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }
        return closestEnemy;
    }

    private void CheckIfEnemyIsInBorder(GameObject enemy)
    {
        float distance = Vector3.Distance(enemy.transform.position,player.transform.position);
        if(distance <= 16.5f)
        {
            isEnemyInBorder = true;
        }

        if (distance > 16.5f)
        {
            isEnemyInBorder = false;
        }
    }

}
