using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCompanion : MonoBehaviour
{
    [SerializeField] GameObject laserBeam;
    [SerializeField] AbilityCooldown abilityCooldown;
    protected ObjectPool pool;
    [SerializeField] string ObjectPoolName;

    SpriteRenderer spriteRenderer;
    Animator animator;

    public float coolDown = 30f;
    public float duration = 10f;

    private float nextCompanion;

    private bool canUseAbility = false;


    private float laserSpawnAngle;
    // Start is called before the first frame update
    void Start()
    {
        GameObject op = GameObject.Find(ObjectPoolName);
        pool = op.GetComponent<ObjectPool>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        spriteRenderer.enabled = false;
        animator.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        RotateToClosestEnemy();

        if (Time.time >= nextCompanion)
        {
            canUseAbility = true;
        }

    }

    public void ShootLaser()
    {
        pool.GetObject(true, new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(0, 0, laserSpawnAngle + 90));
        //Instantiate(laserBeam, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.Euler(0, 0, laserSpawnAngle + 90));
    }

    private GameObject FindClosestEnemy()
    {
        float distanceToClosestEnemy = Mathf.Infinity;
        GameObject closestEnemy = null;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject currentEnemy in enemies)
        {
            float distanceToEnemy = (currentEnemy.transform.position - this.transform.position).sqrMagnitude;
            if (distanceToEnemy < distanceToClosestEnemy)
            {
                distanceToClosestEnemy = distanceToEnemy;
                closestEnemy = currentEnemy;
            }
        }
        return closestEnemy;

    }

    private void RotateToClosestEnemy()
    {
        GameObject enemy = FindClosestEnemy();
        if(enemy == null)
        {
            laserSpawnAngle = -90;
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        if(enemy != null)
        {
            float x = transform.position.x - enemy.transform.position.x;
            float y = transform.position.y - enemy.transform.position.y;

            float angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg;
            laserSpawnAngle = angle;

            transform.eulerAngles = new Vector3(0, 0, angle + 90);
        }
       
    }

    public void ActivateCompanion()
    {

        if (canUseAbility == true)
        {
            spriteRenderer.enabled = true;
            animator.enabled = true;
            nextCompanion = Time.time + coolDown;
            abilityCooldown.StartAbilityIcon();
            StartCoroutine(DeActivateCompanion());
            canUseAbility = false;
        }
    }

    private IEnumerator DeActivateCompanion()
    {
        yield return new WaitForSeconds(10);
        spriteRenderer.enabled = false;
        animator.enabled = false;
    }
}
