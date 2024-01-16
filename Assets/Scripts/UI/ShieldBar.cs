using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBarr : MonoBehaviour
{
    [SerializeField] PlayerPlane player;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float hpRatio = (float)player.playerShield / player.playerMaxShield;
        transform.localScale = new Vector3(hpRatio, 1, 1);
    }
}
