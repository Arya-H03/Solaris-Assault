using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlaneBulletSpawner : MonoBehaviour
{
   
    public int bulletAmount;
    protected Vector3 spawnPosition;

    // Start is called before the first frame update
    public virtual void Start()
    {
        StartCoroutine(FireCoroutine());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void SpawnBullets()
    {

    }

    public virtual IEnumerator FireCoroutine()
    {
        yield return null;
    }


}
