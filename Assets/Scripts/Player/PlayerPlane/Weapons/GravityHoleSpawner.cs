using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityHoleSpawner : MonoBehaviour
{
    [SerializeField] GameObject gravityHole;
    [SerializeField] AbilityCooldown abilityCooldown;

    public float coolDown = 10f;

    private float nextGravityHole;

    private bool canUseAbility = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextGravityHole)
        {
            canUseAbility = true;
        }
    }

    public void SpawnGravityHole()
    {
        if(canUseAbility == true)
        {
            Instantiate(gravityHole, transform.position, Quaternion.identity);
            nextGravityHole = Time.time + coolDown;
            abilityCooldown.StartAbilityIcon();
            canUseAbility= false;
        }
    }
}
