using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlaneProjectile : BasicProjectile
{
   
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
        rb.velocity = transform.up * speed;
    }

}
