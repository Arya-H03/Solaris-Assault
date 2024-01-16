using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleCruiser : Enemy
{
    [SerializeField] GameObject spawnTp;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        StartCoroutine(SpawnAnim());
    }

    IEnumerator SpawnAnim()
    {

        spriteRenderer.enabled= false; 
        GameObject bulletObject = Instantiate(spawnTp, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.55f);
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(0.55f);
        Destroy(bulletObject);
    }
}
