using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossOmega : Enemy
{
    public float moveSpeed = 1f;
    public float lockSpeed = 1f;
    public Vector3 direction;
    private Transform target;
    Rigidbody2D rigidBody2D;

    protected override void Start()
    {
        base.Start();
        transform.position = new Vector3(0, 7, 0);
        rigidBody2D = GetComponent<Rigidbody2D>();
        target = player.transform;
        direction = new Vector3(1, 0, 0);
    }

    protected override void Update()
    {
        base.Update();
        
    }

    public override void EnemyMovementPattern()
    {
        if (target)
        {
            Vector3 directionView = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(directionView.y, directionView.x) * Mathf.Rad2Deg;
            rigidBody2D.rotation = angle - 90f;

            if (transform.position.x > 15f)
            {
                direction.x = -1;
            }
            else if (transform.position.x < -15f)
            {
                direction.x = 1;
            }
            direction.Normalize();
            transform.position += direction * Time.deltaTime * moveSpeed;
        }
    }

}
