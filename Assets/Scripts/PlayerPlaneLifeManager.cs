using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPlaneLifeManager : MonoBehaviour
{

    [SerializeField] Image image1;
    [SerializeField] Image image2;
    [SerializeField] Image image3;

    private bool treshold1 = false;
    private bool treshold2 = false;
    private bool treshold3 = false;

    protected PlayerPlane playerPlane;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerPlane = player.GetComponent<PlayerPlane>();
    }

    private void Update()
    {
        if (playerPlane)
        {
           if(playerPlane.numberOfLives == 2)
           {
                treshold1 = true;
                if (treshold1)
                {
                    image1.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
                }
           }

            if (playerPlane.numberOfLives == 1)
            {
                treshold2 = true;
                if (treshold2)
                {
                    image2.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
                }
            }

            if (playerPlane.numberOfLives == 0)
            {
                treshold3 = true;
                if (treshold3)
                {
                    image2.color = new Color(0.5f, 0.5f, 0.5f, 0.5f);
                }
            }
        }
    }
}
