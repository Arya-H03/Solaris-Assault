using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NairanBulletSpawner : EnemyPlaneBulletSpawner
{
    protected ObjectPool objectPool;
    // Start is called before the first frame update
    public override void Start()
    {
        
        GameObject op = GameObject.Find("BlueBulletPool");
        objectPool = op.GetComponent<ObjectPool>();
        base.Start();
    }

    // Update is called once per frame
    public override IEnumerator FireCoroutine()
    {
        while (true)
        {
            SpawnBullets();
            FirstLevelMusicManager.IsShooting = true;
            yield return new WaitForSeconds(0.05f);
            SpawnBullets();
            yield return new WaitForSeconds(0.05f);
            SpawnBullets();
            yield return new WaitForSeconds(3.0f);
        }
    }
    
    public override void SpawnBullets( )
    {
        for (float i = 0; i <= 4; i++)
        {
            spawnPosition = transform.position;
            GameObject bulletObject = objectPool.GetObject(true, new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(0, 0, 0));
            bulletObject.transform.rotation = new Quaternion(transform.rotation.x,transform.rotation.y, transform.rotation.z + i/100, transform.rotation.w);       
        }
    }
}
