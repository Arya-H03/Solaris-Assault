using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerPlane : MonoBehaviour
{
    private bool isDashing;
    private float dashTimeLeft;
    private float lastImageXpos;
    private float lastImageYpos;
    private float lastDash = -1000f;
    private float dashDirectionX;
    private float dashDirectionY;
    private float nextDashTime;

    private string dashDirection;

    [SerializeField] ObjectPool pool;

    [SerializeField] Level1BgManager level1BgManager;

    [SerializeField] AbilityCooldown dashAbilityCooldownIcon;

    private float movementInputDirectionY;
    private float movementInputDirectionX;

    private Rigidbody2D rb;

    public float speed = 10.0f;

    public float dashTime;
    public float dashSpeed;
    public float distanceBetweenImages;
    public float dashCooldown;
    [SerializeField] PlaneCamera cam;

    public float numberOfLives = 3;
    public float playerHP;
    public float playerMaxHP = 100f;
    public float playerMaxShield = 150f;
    public float playerShield;

    public float shieldReChargeTime = 0.1f; // each n second the shield recharges 
    public float shieldReChargeAmount = 1f;
    private float nextShieldRechargeTime;
    private bool canRecharge = true;
    public float rechargeDelayIfHit = 2f;
    private SpriteRenderer spriteRenderer;

    public bool isShieldActive = true;
    [SerializeField] private Material material;

    [SerializeField] TMP_Text HealthPer;
    [SerializeField] TMP_Text ShieldPer;

    [SerializeField] PlaneCamera planeCamera;

    //[SerializeField] SpriteRenderer hitbox;

    [SerializeField] SfxManager sfxManager;

    ParticleSystem ps;



    private bool isInvincible;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(ShakeCoroutine());
        rb = GetComponent<Rigidbody2D>();
        playerHP = playerMaxHP;
        playerShield = playerMaxShield;
        spriteRenderer = GetComponent<SpriteRenderer>();
        material = spriteRenderer.material;
        ps = GameObject.Find("PlaneVFXholder").GetComponent<ParticleSystem>();
        ps.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();

        RechargeShield();

        //if (Time.time >= nextDashTime)
        //{
        //    if (Input.GetButtonDown("Jump") == true && Input.GetAxisRaw("Vertical") != 0)
        //    {

        //        dashDirection = "vertical";

        //        if (Input.GetAxisRaw("Vertical") >= 0)
        //        {
        //            dashDirectionY = 1;
        //            AttemptToDash();
        //            dashAbilityCooldownIcon.StartAbilityIcon();
        //            nextDashTime = Time.time + dashCooldown;
        //        }

        //    }

        //    if (Input.GetButtonDown("Jump") == true && Input.GetAxisRaw("Horizontal") != 0)
        //    {

        //        dashDirection = "horizontal";

        //        if (Input.GetAxisRaw("Horizontal") >= 0)
        //        {
        //            dashDirectionX = 1;
        //        }

        //        if (Input.GetAxisRaw("Horizontal") < 0)
        //        {
        //            dashDirectionX = -1;
        //        }

        //        AttemptToDash();
        //        nextDashTime = Time.time + dashCooldown;
        //    }
        //}
        ////make hitbox disappear
        //if (!Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        //{
        //    speed = 10;
        //    hitbox.enabled = false;
        //}
        ////make hitbox appear
        //if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        //{
        //    speed = 5;
        //    hitbox.enabled = true;
        //}
        //checkdash
        CheckDash();

        UpdateHealthAndShieldPer();
    }

    private void FixedUpdate()
    {
        ApplyMovement(speed);
    }
    private void CheckInput()
    {
        movementInputDirectionY = Input.GetAxisRaw("Vertical");
        movementInputDirectionX = Input.GetAxisRaw("Horizontal");

    }

    private void ApplyMovement(float speed)
    {
        if(Time.timeScale == 1)
        {
            float helpSpeed = speed;


            if (CheckYDirection() == "None")
            {
                helpSpeed = 0f;
            }
            else if (CheckYDirection() == "Forward")
            {
                helpSpeed = speed;
            }
            else if (CheckYDirection() == "BackWard")
            {
                helpSpeed = speed * 0.25f;
            }

            rb.velocity = new Vector2(movementInputDirectionX * speed, movementInputDirectionY * helpSpeed);
        }
       
    }

    private void AttemptToDash()
    {
        isDashing = true;
        dashTimeLeft = dashTime;
        lastDash = Time.time;
        //ObjectPool.Instance.GetObject(false, Vector3.zero, Vector3.zero);
        lastImageYpos = transform.position.y;
        lastImageXpos = transform.position.x;

    }

    private void CheckDash()
    {
        if (isDashing)
        {
            if (dashTimeLeft > 0)
            {


                if (dashDirection == "vertical")
                {
                    transform.position += new Vector3(0, dashSpeed * dashDirectionY, 0);
                    //rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, dashSpeed * 20);


                    if (Mathf.Abs(transform.position.y - lastImageYpos) > distanceBetweenImages)
                    {
                        //ObjectPool.Instance.GetObject(false,Vector3.zero,Vector3.zero);
                        lastImageYpos = transform.position.y;
                    }


                }

                if (dashDirection == "horizontal")
                {
                    transform.position += new Vector3(dashSpeed * dashDirectionX, 0, 0);

                    if (Mathf.Abs(transform.position.x - lastImageXpos) > distanceBetweenImages)
                    {
                        //ObjectPool.Instance.GetObject(false, Vector3.zero, Vector3.zero);
                        lastImageXpos = transform.position.x;
                    }

                }

                dashTimeLeft -= Time.deltaTime;

            }

            if (dashTimeLeft <= 0)
            {
                isDashing = false;
            }



        }
    }

    public bool TakeDamage(float damageTaken)
    {
        if (!isInvincible)
        {
            sfxManager.PlayerHit();
            StartCoroutine(AfterDamageParticleSystem());
            planeCamera.shakeMagnitude = 0.25f;
            planeCamera.Shake();
            isInvincible = true;
            StartCoroutine(InvincibleCoroutine());
            StartCoroutine(CanShieldRecharge());
            cam.ShakeCamera();
            if (playerShield < 0)
            {
                playerShield = 0;
            }

            if (playerShield <= 0)
            {
                isShieldActive = false;
                playerHP -= damageTaken;
            }

            if (playerShield > 0)
            {
                playerShield -= damageTaken;
            }

            if (playerHP <= 0)
            {

                numberOfLives--;
                playerHP = playerMaxHP;
                playerShield = playerMaxShield;
            }

            if (playerShield < 0)
            {
                playerShield = 0;
            }

            if (numberOfLives <= 0)
            {
                SceneManager.LoadScene("DeathScene");
               
            }

            return true;
        }
        return false;
    }

    IEnumerator InvincibleCoroutine()
    {
        isInvincible = true;
        yield return new WaitForSeconds(0.1f);
        isInvincible = false;
    }

    IEnumerator CanShieldRecharge()
    {
        canRecharge = false;
        yield return new WaitForSeconds(rechargeDelayIfHit);
        canRecharge = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyPlaneProjectile enemyPlaneProjectile = collision.GetComponent<EnemyPlaneProjectile>();
        Enemy enemy = collision.GetComponent<Enemy>();
        if (enemyPlaneProjectile || enemy)
        {
            StartCoroutine(HitMarker());
            enemyPlaneProjectile.DeActivate(0);
        }
        if (enemyPlaneProjectile)
        {
            TakeDamage(enemyPlaneProjectile.damage);
        }



    }

    private void RechargeShield()
    {
        if (Time.time >= nextShieldRechargeTime && canRecharge == true)
        {
            if (playerShield <= playerMaxShield)
            {
                playerShield += shieldReChargeAmount;
                nextShieldRechargeTime = Time.time + shieldReChargeTime;
            }

            if (playerShield > playerMaxShield)
            {
                playerShield = playerMaxShield;
            }

        }
    }

    IEnumerator HitMarker()
    {
        material.SetFloat("_Flash", 1.0f);
        yield return new WaitForSeconds(0.05f);
        material.SetFloat("_Flash", 0.0f);
    }

    private string CheckYDirection()
    {
        string direction = "None";
        if (movementInputDirectionY > 0)
        {
            ChangeBackGroundSpeed(2f);
            direction = "Forward";

        }

        else if (movementInputDirectionY < 0)
        {
            ChangeBackGroundSpeed(-1.25f);
            direction = "Backward";

        }

        else if (movementInputDirectionY == 0)
        {
            ChangeBackGroundSpeed(1f);
            direction = "None";
        }

        return direction;
    }
    private void ChangeBackGroundSpeed(float s)
    {
        level1BgManager.speed = s;
    }

    private void UpdateHealthAndShieldPer()
    {
        float HpRatio = playerHP / playerMaxHP;
        float ShieldRatio = playerShield / playerMaxShield;

        HealthPer.text = Mathf.CeilToInt(HpRatio * 100).ToString() + "%";
        ShieldPer.text = Mathf.CeilToInt(ShieldRatio * 100).ToString() + "%";
    }

    private IEnumerator AfterDamageParticleSystem()
    {
        ps.Play();
        yield return new WaitForSeconds(0.25f);
        ps.Stop();
    }

}
