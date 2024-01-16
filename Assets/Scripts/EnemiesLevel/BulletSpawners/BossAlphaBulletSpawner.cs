using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAlphaBulletSpawner : EnemyPlaneBulletSpawner
{
    protected ObjectPool objectPool;
    [SerializeField] Enemy alpha;

    // Start is called before the first frame update
    public override void Start()
    {

        GameObject op = GameObject.Find("YellowBulletPool");
        objectPool = op.GetComponent<ObjectPool>();
        base.Start();
    }


    public override IEnumerator FireCoroutine()
    {
        yield return new WaitForSeconds(2f);
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            SpawnBullets();
        }

    }
    public override void SpawnBullets()
    {
        spawnPosition = transform.position;
        float angleIncrement = 4;
        GameObject bulletObject = objectPool.GetObject(true, spawnPosition, new Vector3(0, 0, 0));

        bulletObject.transform.rotation = transform.rotation;
        transform.Rotate(0, 0, angleIncrement);

        GameObject bulletObject2 = objectPool.GetObject(true, spawnPosition, new Vector3(0, 0, 0));

        bulletObject2.transform.rotation = transform.rotation;
        transform.Rotate(0, 0, angleIncrement + 180);

    }
}
