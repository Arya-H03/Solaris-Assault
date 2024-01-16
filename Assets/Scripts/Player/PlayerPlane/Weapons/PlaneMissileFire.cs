using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlaneMissileFire : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] float coolDown;
    Animator animator;

    protected ObjectPool pool;
    [SerializeField] string ObjectPoolName;

    [SerializeField] float missile1Xpos;
    [SerializeField] float missile2Xpos;
    [SerializeField] float missile3Xpos;
    
    [SerializeField] public int roundOfFire;

    [SerializeField] AbilityCooldown AbilityCooldownIcon;

    private float nextMissileFire;

    private bool canShootMissile = false;





    // Start is called before the first frame update
    void Start()
    {
        GameObject op = GameObject.Find(ObjectPoolName);
        pool = op.GetComponent<ObjectPool>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextMissileFire)
        {
            canShootMissile = true;
        }

    }


    public void FireMissile1()
    {
        StartCoroutine(SpawnMissiles(obj, missile1Xpos));
    
    }

    public void FireMissile2()
    {
        StartCoroutine(SpawnMissiles(obj, missile2Xpos));
    }

    public void FireMissile3()
    {
        StartCoroutine(SpawnMissiles(obj, missile3Xpos));
    }

    IEnumerator MissileCooldownCoroutine()
    {
        yield return new WaitForSeconds(coolDown);
        animator.SetTrigger("reloaded");
    }

    IEnumerator SpawnMissiles(GameObject obj, float posX)
    {
        for(int i = 0; i < roundOfFire; i++)
        {
            pool.GetObject(true, new Vector3(transform.position.x + posX, transform.position.y, transform.position.z), new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z));
           
            yield return new WaitForSeconds(1f);
        }
    }

    public void ShootMissile()
    {
        if(canShootMissile == true)
        {
            animator.SetTrigger("Shoot");
            AbilityCooldownIcon.StartAbilityIcon();
            StartCoroutine(MissileCooldownCoroutine());

            nextMissileFire = Time.time + coolDown;
            canShootMissile = false;
        }
       
    }
}
