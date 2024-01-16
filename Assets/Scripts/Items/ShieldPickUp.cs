using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldPickUp : MonoBehaviour
{
    [SerializeField] int shieldBoost;

    Rigidbody2D rb;

    private int destroyTimer = 5;
    // Start is called before the first frame update
    void Start()
    {
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
            playerPlane.playerMaxShield += shieldBoost;
            Destroy(this.gameObject);
        }
    }

    private IEnumerator SelfDestroyCoroutine()
    {
        yield return new WaitForSeconds(destroyTimer);
        Destroy(this.gameObject);
    }
}
