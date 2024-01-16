using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticField : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    GameObject player;

    public bool isActive;
    private bool canEMP = false;

    //When will the field expands
    private float nextExpandTime = 0;
    //How often the field expands
    private float expandRate = 0.01f;

    private float nextMagneticCast = 0f;

    Color spriteColor;

    [SerializeField] AbilityCooldown magneticFieldAbilityCooldownIcon;

    public float magneticFieldCooldown = 30f;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteColor = spriteRenderer.color;
        player = GameObject.FindGameObjectWithTag("Player");
      
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        if (isActive == true)
        {
            if (Time.time >= nextExpandTime)
            {
                
                transform.localScale += new Vector3(0.25f, 0.25f, 0);
                spriteColor.a -= 0.01f;
                spriteRenderer.color = spriteColor;

                nextExpandTime = Time.time + expandRate;
                
            }

            //takes about 1 second
            if (spriteColor.a <= 0)
            {
                DeActivateField();
            }
        }

        if (Time.time >= nextMagneticCast)
        {
            canEMP = true;
        }

    }

    //private void ActivateField()
    //{
    //    isActive = true;
    //}

    private void DeActivateField()
    {
        isActive = false;
        spriteColor.a = 1;
        transform.localScale = new Vector3(0, 0, 1);
    }

    public void ActivateEMP()
    {
        if(canEMP == true)
        {
            isActive = true;
            magneticFieldAbilityCooldownIcon.StartAbilityIcon();
            nextMagneticCast = Time.time + magneticFieldCooldown;
            canEMP = false;
        }
       
    }

    private void Movement()
    {
        //for following player
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyPlaneProjectile enemyPlaneProjectile = collision.GetComponent<EnemyPlaneProjectile>();
        if (enemyPlaneProjectile)
        {
            enemyPlaneProjectile.DeActivate(0.2f);
        }
    }

}
