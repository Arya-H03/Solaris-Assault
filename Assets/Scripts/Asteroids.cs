using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Asteroids : MonoBehaviour
{
    [SerializeField] protected float speed = 1f;
    [SerializeField] float damage;
    [SerializeField] int enemyHP;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction;
        direction = new Vector3(0, -1, 0);
        direction.Normalize();
        transform.position += direction * Time.deltaTime * speed;
    }
    public void TakeDamage(int damageValue)
    {
        enemyHP -= damageValue;
       
        if (enemyHP <= 0)
        {
            animator.SetBool("isExploding", true);
          
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerPlane playerPlane = collision.GetComponent<PlayerPlane>();
        if (playerPlane)
        {
            playerPlane.TakeDamage(damage);
            animator.SetBool("isExploding", true);
        }
        if (collision.CompareTag("MapBorders"))
        {
            animator.SetBool("isExploding", true);
        }
    }

    public void Destroy()
    {
        Destroy(this.gameObject);
    }
}
