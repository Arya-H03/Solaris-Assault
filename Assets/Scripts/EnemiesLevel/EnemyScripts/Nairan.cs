using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nairan : Enemy
{
    private Transform target;
    Vector2 moveDirection;
    Rigidbody2D rigidBody2D;

    private float movementDuration = 2.0f;
    private float waitBeforeMoving = 2.0f;
    private bool hasArrived = false;

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

    private IEnumerator MoveToPoint(Vector3 targetPos)
    {
        float timer = 0.0f;
        Vector3 startPos = transform.position;

        while(timer < movementDuration)
         {
            timer += Time.deltaTime;
            float t = timer / movementDuration;
            t = t * t * t * (t * (6f * t - 15f) + 10f);
            transform.position = Vector3.Lerp(startPos, targetPos, t);

            yield return null;
         }

        yield return new WaitForSeconds(waitBeforeMoving);
        hasArrived = false;
    }

    public override void EnemyMovementPattern()
    {
        if (target)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rigidBody2D.rotation = angle - 90f;
        }
        if (!hasArrived)
        {
            hasArrived = true;
            float randX = Random.Range(-5.0f, 5.0f);
            float randZ = Random.Range(-5.0f, 5.0f);
            StartCoroutine(MoveToPoint(new Vector3(randX, -1.504f, randZ)));
        }
    }

}
