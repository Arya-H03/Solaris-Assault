using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarabBulletSpawner : EnemyPlaneBulletSpawner
{
    protected ObjectPool objectPool;
    // Start is called before the first frame update
    public override void Start()
    {
        GameObject op = GameObject.Find("RedBulletPool");
        objectPool = op.GetComponent<ObjectPool>();
        base.Start();
        
        
    }

    // Update is called once per frame
    public override IEnumerator FireCoroutine()
    {
        while (true)
        {
            //FirstLevelMusicManager.IsPew = true;
            SpawnBullets();
            yield return new WaitForSeconds(1.0f);
        }
    }

    public override void SpawnBullets()
    {
        for (float i = 0; i <= 4; i++)
        {
            spawnPosition = transform.position;
            GameObject bulletObject = objectPool.GetObject(true, new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(0, 0, 0));
            bulletObject.transform.rotation = transform.rotation;
                       
        }
    }

    
}
