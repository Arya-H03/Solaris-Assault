using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilePickUp : MonoBehaviour
{

    private HomingMissileSpawner homingMissileSpawner;
    private PlaneMissileFire rightWing;
    private PlaneMissileFire leftWing;

    Rigidbody2D rb;

    private int destroyTimer = 5;
    // Start is called before the first frame update
    void Start()
    {
        GameObject RW = GameObject.FindGameObjectWithTag("RightWing");
        rightWing = RW.GetComponent<PlaneMissileFire>();
        GameObject LW = GameObject.FindGameObjectWithTag("LeftWing");
        leftWing = LW.GetComponent<PlaneMissileFire>();
        GameObject HMS = GameObject.FindGameObjectWithTag("HomingMissileSpawner");
        rb = GetComponent<Rigidbody2D>();
        homingMissileSpawner = HMS.GetComponent<HomingMissileSpawner>();

        StartCoroutine(SelfDestroyCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2 (0,-1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPlane playerplane = collision.GetComponent<PlayerPlane>();
        if (playerplane)
        {
            homingMissileSpawner.numberOfVolleys++;
            rightWing.roundOfFire++;
            leftWing.roundOfFire++;

            Destroy(this.gameObject);
        }
    }

    private IEnumerator SelfDestroyCoroutine()
    {
        yield return new WaitForSeconds(destroyTimer);
        Destroy(this.gameObject);
    }
}
