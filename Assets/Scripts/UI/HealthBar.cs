using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] PlayerPlane player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float hpRatio = (float)player.playerHP / player.playerMaxHP;
        transform.localScale = new Vector3(hpRatio, 1, 1);
    }
}
