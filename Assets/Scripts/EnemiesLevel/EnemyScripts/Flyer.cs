using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flyer : Enemy
{
    [SerializeField] float speed = 8f;
   
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

    public override void EnemyMovementPattern()
    {
        Vector3 direction;
        direction = new Vector3(-1, 0, 0);
        direction.Normalize();
        transform.position += direction * Time.deltaTime * speed;
    }

}
