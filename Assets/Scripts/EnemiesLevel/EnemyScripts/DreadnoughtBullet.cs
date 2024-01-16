using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DreadnoughtBullet : MonoBehaviour
{
    public float movementSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * movementSpeed * Time.deltaTime;
    }

}
