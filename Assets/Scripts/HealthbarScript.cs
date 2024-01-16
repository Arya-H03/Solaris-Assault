using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthbarScript : MonoBehaviour
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
        if(hpRatio >= 0)
        {
            transform.localScale = new Vector3(hpRatio, hpRatio, 1);
        }
        
    }
}
