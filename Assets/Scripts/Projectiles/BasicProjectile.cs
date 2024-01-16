using System.Collections;
using UnityEngine;

public class BasicProjectile : MonoBehaviour
{
    public float speed;
    public int directionY;
    protected ObjectPool pool;
    protected GameObject player;
    [SerializeField] string ObjectPoolName;
    public int damage;
    public Rigidbody2D rb;

    public bool isGoingToGravityHole;

    protected virtual void Start()
    {
        GameObject op = GameObject.Find(ObjectPoolName);
        pool = op.GetComponent<ObjectPool>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        CheckProjectileMovement();
    }
    
    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {       
         if (collision.CompareTag("MapBorders") || collision.CompareTag("BottomMapBorder"))
        {
            DeActivate(0);
        }
    }

    protected virtual void ProjectileMoving()
    {
        rb.velocity = new Vector3(0, directionY * speed, 0);
        //transform.position += new Vector3(0, directionY, 0) * speed * Time.deltaTime;
    }

    protected virtual void CheckProjectileMovement()
    {      
        if (isGoingToGravityHole == false )
        {
            ProjectileMoving();
        }      
    }
    
    private IEnumerator DeActivatePeojectileCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);
        pool.ReturnObject(this.gameObject);
    }

    public void DeActivate(float Seconds)
    {
        StartCoroutine(DeActivatePeojectileCoroutine(Seconds));
    }

    public void ResetSpeed()
    {
        rb.velocity = new Vector3(0, directionY * speed, 0);
    }


}
