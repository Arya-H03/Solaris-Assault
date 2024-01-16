using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Dreadnought : Enemy
{
    public float moveSpeed = 1f;
    public Vector3 direction;

    protected override void Start()
    {
        base.Start();
        transform.position = new Vector3(0, 7, 0);
        direction = new Vector3(1, 0, 0);
    }

    protected override void Update()
    {
       base.Update();
    }

    public override void EnemyMovementPattern()
    {
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
