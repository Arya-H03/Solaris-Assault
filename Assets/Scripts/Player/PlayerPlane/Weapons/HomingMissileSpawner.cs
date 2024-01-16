using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissileSpawner : MonoBehaviour
{
    [SerializeField] PlayerHomingMissile homingMissile;
    [SerializeField] AbilityCooldown abilityCooldown;
    protected ObjectPool pool;
    [SerializeField] string ObjectPoolName;

    [SerializeField] public int numberOfVolleys;

    public float coolDown = 5f;

    private float nextHomingMissile;

    private bool canUseAbility = false;
    // Start is called before the first frame update
    private void Start()
    {
        GameObject op = GameObject.Find(ObjectPoolName);
        pool = op.GetComponent<ObjectPool>();
    }
    void Update()
    {
        if (Time.time >= nextHomingMissile)
        {
            canUseAbility = true;
        }
    }

    public void SpawnHomingMissile()
    {
        if (canUseAbility == true)
        {
            StartCoroutine(CreateMissiles());
           
            nextHomingMissile = Time.time + coolDown;
            abilityCooldown.StartAbilityIcon();
            canUseAbility = false;
        }
    }

    private IEnumerator CreateMissiles()
    {
        for(int i =0; i<numberOfVolleys; i++)
        {
            pool.GetObject(true, new Vector3(transform.position.x + 0.5f, transform.position.y, transform.position.z), new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z));
            pool.GetObject(true, new Vector3(transform.position.x - 0.5f, transform.position.y, transform.position.z), new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z));

            yield return new WaitForSeconds(0.5f);
        }
    }
}
