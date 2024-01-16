using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlaneGun : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] ObjectPool objectPool;

    [SerializeField] Image heatBar1;
    [SerializeField] Image heatBar2;

    [SerializeField] TMP_Text heatPer;

    public int damage;

    private float nextShotTime;
    public float timeBetweenShots = 0.5f;

    private bool overHeat = false;
    private int heatCounter = 0;
    public int maxHeat = 250;
    public float heatTransitionSpeed = 0.5f;

    private Color red = new Color(1f, 0.27f, 0f);

    public float cooldownTime = 1f;
    private bool isCoolingDown = false; 
    private float cooldownTimer = 0f; 

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetMouseButton(0))
        {
            if (Time.time >= nextShotTime && overHeat == false)
            {
                ShootBullets();
                nextShotTime = Time.time + timeBetweenShots;
               
            }
            
        }

        CheckHeating();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

    private void ShootBullets()
    {
       
        if(heatCounter >= maxHeat)
        {
            overHeat = true;
        }
        if (!overHeat)
        {
            BasicProjectile bullet1 = objectPool.GetObject(true, new Vector3(transform.position.x - 0.3f, transform.position.y - 0.2f, transform.position.z), new Vector3(0, 0, 90)).GetComponent<BasicProjectile>();
            bullet1.ResetSpeed();
            heatCounter++;
            BasicProjectile bullet2 = objectPool.GetObject(true, new Vector3(transform.position.x + 0.3f, transform.position.y - 0.2f, transform.position.z), new Vector3(0, 0, 90)).GetComponent<BasicProjectile>();
            bullet2.ResetSpeed();
            heatCounter++;
            cooldownTimer = 0f;
            isCoolingDown = false;
        }
       

    }

    private void CheckForHeatBarColor()
    {
        float heatPercentage = (float)heatCounter / maxHeat;
        heatPer.text = Mathf.CeilToInt(heatPercentage * 100).ToString() + "%";
        Color targetColor = Color.Lerp(Color.white, red, heatPercentage);
        heatBar1.color = Color.Lerp(heatBar1.color, targetColor, heatTransitionSpeed * Time.deltaTime);
        heatBar2.color = Color.Lerp(heatBar2.color, targetColor, heatTransitionSpeed * Time.deltaTime);
    }     
    private void CheckHeating()
    {
        if (heatCounter > 0 && !isCoolingDown)
        {

            cooldownTimer += Time.deltaTime;
            if (cooldownTimer >= cooldownTime)
            {
                isCoolingDown = true;
            }
        }

        if (isCoolingDown)
        {
            heatCounter--;
            if (heatCounter <= 0)
            {
                heatCounter = 0;
                isCoolingDown = false;
            }
        }

        if (heatCounter <= 98)
        {
            overHeat = false;
        }
        CheckForHeatBarColor();

    }
}
