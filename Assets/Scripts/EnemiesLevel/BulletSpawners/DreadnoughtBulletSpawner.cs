using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class DreadnoughtBulletSpawner : EnemyPlaneBulletSpawner
{
    protected ObjectPool objectPool;
    // Start is called before the first frame update
    public override void Start()
    {

        GameObject op = GameObject.Find("GreenBulletPool");
        objectPool = op.GetComponent<ObjectPool>();
        base.Start();
    }

    // Update is called once per frame
    public override IEnumerator FireCoroutine()
    {
        while(true) 
        { 
            SpawnBullets();
            yield return new WaitForSeconds(4f);
        }
    }

    public override void SpawnBullets() 
    {
        float angleIncrement = 180 / bulletAmount;
        for (float i = 0; i <= bulletAmount; i ++)
        {
            spawnPosition = transform.position - new Vector3(0, 1.5f);
            GameObject bulletObject = objectPool.GetObject(true, spawnPosition, new Vector3(0, 0, 0));
            bulletObject.transform.rotation = transform.rotation;
            transform.Rotate(0, 0, angleIncrement);
        
        }
        transform.Rotate(0, 0, 180 - angleIncrement);
    }
}



