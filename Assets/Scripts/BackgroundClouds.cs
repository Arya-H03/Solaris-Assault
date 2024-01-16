using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundClouds : MonoBehaviour
{
    ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            ParticleSystem.MainModule mainModule = ps.main;
            mainModule.startSpeed = 30f;
            mainModule.maxParticles = 15;
        }

        if (Input.GetAxisRaw("Vertical") == 0)
        {
            ParticleSystem.MainModule mainModule = ps.main;
            mainModule.startSpeed = 6f;
            mainModule.maxParticles = 10;
        }
    }
}

