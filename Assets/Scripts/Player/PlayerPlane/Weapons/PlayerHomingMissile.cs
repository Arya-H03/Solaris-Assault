using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHomingMissile : FriendlyProjectile
{
    private Transform target;
    private bool isEnemyInBorder = false;
    public float curveStrength = 1.0f;
    protected override void Start()
    {
        base.Start();
    }
    protected override void Update()
    {

        ProjectileMoving();

    }

    private GameObject TrackEnemy()
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

    protected override void ProjectileMoving()
    {
        GameObject enemy = TrackEnemy();
        if (enemy)
        {
            CheckIfEnemyIsInBorder(enemy);
        }

        if (TrackEnemy() != null && isEnemyInBorder == true)
        {
            target = TrackEnemy().transform;
            // Calculate the direction to the target
            Vector2 direction = (target.position - transform.position).normalized;
            // Apply the curve to the direction
            direction = Quaternion.Euler(0, 0, curveStrength * Mathf.Sin(Time.time)) * direction;
            // Move the missile in the curved direction
            transform.position += (Vector3)direction * speed * Time.deltaTime;
            // Calculate the rotation to face the target
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);
            // Apply the rotation to the missile
            transform.rotation = rotation;
        }
        if(TrackEnemy() == null || isEnemyInBorder == false)
        {
            transform.position += new Vector3(0,1,0) * speed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

       
       
    }

    private void CheckIfEnemyIsInBorder(GameObject enemy)
    {
        float distance = Vector3.Distance(enemy.transform.position, player.transform.position);
        if (distance <= 16.5f)
        {
            isEnemyInBorder = true;
        }

        if (distance > 16.5f)
        {
            isEnemyInBorder = false;
        }
    }




}
