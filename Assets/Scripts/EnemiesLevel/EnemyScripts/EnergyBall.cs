using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBall : MonoBehaviour
{
    [SerializeField] protected float speed = 1f;
    protected ObjectPool pool;
    [SerializeField] string ObjectPoolName;
    [SerializeField] float  damage;

    // Start is called before the first frame update
     void Start()
    {
        GameObject op = GameObject.Find(ObjectPoolName);
        pool = op.GetComponent<ObjectPool>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction;
        direction = new Vector3(0, -1, 0);
        direction.Normalize();
        transform.position += direction * Time.deltaTime * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPlane playerPlane = collision.GetComponent<PlayerPlane>();
        if (playerPlane)
        {
            playerPlane.TakeDamage(damage);
            pool.ReturnObject(this.gameObject);
        }
        if (collision.CompareTag("MapBorders"))
        {
            pool.ReturnObject(this.gameObject);
        }
    }

}
