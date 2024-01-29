using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private SfxManager sfxManager;
    public int enemyHP = 1;
    public int maxHp = 1;

    [SerializeField] int scoreValue;

    [SerializeField] GameObject shieldBoostItem;
    [SerializeField] GameObject missileBoostItem;
    [SerializeField] GameObject gunUpgradeItem;

    protected Material material;
    protected SpriteRenderer spriteRenderer;
    protected GameObject player;
    protected Animator animator;
    private ScoreManager scoreManager;

    protected bool isEmp = false;
    public float EMPduration = 2f;

    protected bool isExploding = false;

    public bool canGetDestroyed = true;    
    // Start is called before the first frame update

    protected virtual void Start()
    {
        //SFXManager = GameObject.FindGameObjectWithTag("SFX");
        //sfxManager = SFXManager.GetComponent<SfxManager>();
       sfxManager = GameObject.FindObjectOfType<SfxManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        material = spriteRenderer.material;
        scoreManager = GameObject.FindObjectOfType<ScoreManager>();
    }

    protected virtual void Update()
    {
        EnemyMovement();
    }

    public virtual void TakeDamage(int damageValue)
    {
        enemyHP -= damageValue;
        sfxManager.PlayEnemyHit();
        if (enemyHP <= 0)
        {
            
            animator.SetBool("isExploding", true);
            sfxManager.PlayEnemyDead();

        }
    }


    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BottomMapBorder"))
        {
            Destroy(this.gameObject);
        }
        PlayerPlane playerPlane = collision.GetComponent<PlayerPlane>();
        if (playerPlane)
        {
            StartCoroutine(HitMarker());
            playerPlane.playerShield = 0;
            playerPlane.playerHP -= 10;
        }


        MagneticField magneticField = collision.GetComponent<MagneticField>();
        if (magneticField)
        {
            StartCoroutine(Emp());
        }
    }
    IEnumerator HitMarker()
    {
        material.SetFloat("_Flash", 1.0f);
        yield return new WaitForSeconds(0.02f);
        material.SetFloat("_Flash", 0.0f);
    }

    IEnumerator Emp()
    {
        isEmp = true;
        yield return new WaitForSeconds(EMPduration);
        isEmp = false;
    }

    public void HitMarkerFuntion()
    {
        if (gameObject.activeSelf)
        {
            StartCoroutine(HitMarker());
        }
        
    }

    private void EnemyMovement()
    {
        if(isEmp == false)
        {
            EnemyMovementPattern();
        }

    }

    public virtual void EnemyMovementPattern()
    {

    }

    public void Destroy()
    {
        DropItem();
        scoreManager.UpdateScore(scoreValue);
        Destroy(this.gameObject);
    }

    protected void DropItem()
    {
        int randomNumber = Random.Range(1, 101);
        int randomXOffset = Random.Range(1, 3);
        int randomYOffset = Random.Range(1, 3);

            if (randomNumber < 6)
            {
                Instantiate(shieldBoostItem,new Vector3(transform.position.x + randomXOffset, transform.position.y + randomYOffset, transform.position.z),  Quaternion.identity);
            }

            if (randomNumber < 10 && randomNumber >= 6)
            {
                Instantiate(missileBoostItem, new Vector3(transform.position.x + randomXOffset, transform.position.y + randomYOffset, transform.position.z), Quaternion.identity);
            }

            if (randomNumber < 15 && randomNumber >= 10)
            {
                Instantiate(gunUpgradeItem, new Vector3(transform.position.x + randomXOffset, transform.position.y + randomYOffset, transform.position.z), Quaternion.identity);
            }
        
    }

}
