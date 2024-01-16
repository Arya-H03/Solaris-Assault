using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBar : MonoBehaviour
{
    [SerializeField] PlayerPlane player;
    private float m = 2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float hpRatio = (float)player.playerShield / player.playerMaxShield;
        if (hpRatio > 0)
        {
            transform.localScale = new Vector3(1-((1-hpRatio) / m), 1 - ((1 - hpRatio) / m), 1);
        }
        if(hpRatio == 0)
        {
            transform.localScale = new Vector3(0,0, 1);
        }

    }
}
