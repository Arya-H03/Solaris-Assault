using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scarab : Enemy
{
    [SerializeField] protected float speed = 1f;
    private Transform target;
    Vector2 moveDirection;
    Rigidbody2D rigidBody2D;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        rigidBody2D = GetComponent<Rigidbody2D>();
        target = player.transform;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
       
    }

    public override void EnemyMovementPattern()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rigidBody2D.rotation = angle - 90f;
            direction = new Vector3(0, -1, 0);
            direction.Normalize();
            transform.position += direction * Time.deltaTime * speed;
        }
    }

   

}
