using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityHole : MonoBehaviour
{
    public float forceStrength = 5f;
    public float range = 5f;

    public float travelDuration;
    public float travelSpeed = 5f;

    private float startTime;

    public float duration = 5f;

    private bool isAboutToGetDestroyed = false;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        startTime = Time.time;
        StartCoroutine(MoveForward());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startTime > duration)
       {
            isAboutToGetDestroyed = true;
            StartCoroutine(DeActivateCoroutine());
       }
        CheckProjectile();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        BasicProjectile basicProjectile = collision.GetComponent<BasicProjectile>();
        if (basicProjectile)
        {
            basicProjectile.DeActivate(0f);
        }
    }

    private IEnumerator MoveForward()
    {
        while (Time.time - startTime < travelDuration)
        {
            rb.velocity = new Vector2(0, 1 * travelSpeed);
            yield return null;
        }

        if(Time.time - startTime > travelDuration)
        {
            rb.velocity = new Vector2(0, 0);
           
        }
    }

    private void CheckProjectile()
    {
        BasicProjectile[] basicProjectiles = GameObject.FindObjectsOfType<BasicProjectile>();
        if (isAboutToGetDestroyed == false)
        {
            for (int i = 0; i < basicProjectiles.Length; i++)
            {
                if (basicProjectiles[i] != null)
                {
                    if ((this.transform.position - basicProjectiles[i].transform.position).sqrMagnitude <= range)
                    {
                        basicProjectiles[i].isGoingToGravityHole = true;

                        Vector2 direction = (transform.position - basicProjectiles[i].transform.position).normalized;
                        basicProjectiles[i].rb.velocity = new Vector2(direction.x * forceStrength, direction.y * forceStrength);
                    }

                    if ((this.transform.position - basicProjectiles[i].transform.position).sqrMagnitude > range || isAboutToGetDestroyed)
                    {
                        basicProjectiles[i].isGoingToGravityHole = false;
                    }

                }
            }
        }

            if(isAboutToGetDestroyed == true)
            {
                for (int i = 0; i < basicProjectiles.Length; i++)
                {

                    basicProjectiles[i].isGoingToGravityHole = false;
                }
            }
   

    }

    
    private IEnumerator DeActivateCoroutine()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);   
    }
}


