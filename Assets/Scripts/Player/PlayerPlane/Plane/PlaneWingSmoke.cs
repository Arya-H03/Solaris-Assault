using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneWingSmoke : MonoBehaviour
{
    ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        ps.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Vertical") != 0)
        {
            ParticleSystem.MainModule mainModule = ps.main;
            mainModule.startSpeed = 15f ;

            ps.Play();
           
        }

        if (Input.GetAxisRaw("Vertical") == 0)
        {
            ParticleSystem.MainModule mainModule = ps.main;
            mainModule.startSpeed = 6f;
            ps.Stop();
        }
    }
}
