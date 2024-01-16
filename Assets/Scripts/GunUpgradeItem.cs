using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunUpgradeItem : MonoBehaviour
{
    private PlaneGun planeGun;

    Rigidbody2D rb;

    private int destroyTimer = 5;
    // Start is called before the first frame update
    void Start()
    {
        planeGun = GameObject.FindObjectOfType<PlaneGun>();
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(SelfDestroyCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, -1);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPlane playerPlane = collision.GetComponent<PlayerPlane>();
        if (playerPlane)
        {
            planeGun.maxHeat += 25;
            planeGun.cooldownTime -= 0.1f;

            Destroy(this.gameObject);
        }
    }

    private IEnumerator SelfDestroyCoroutine()
    {
        yield return new WaitForSeconds(destroyTimer);
        Destroy(this.gameObject);
    }
}
