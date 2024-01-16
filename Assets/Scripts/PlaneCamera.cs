using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneCamera : MonoBehaviour
{
    [SerializeField] Transform playerPlane;

    public float shakeDuration = 0.2f;
    public float shakeMagnitude = 0.5f;

    private Vector3 originalPosition;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float positionX = playerPlane.position.x;
        //float positionY = playerPlane.position.y;
        //float positionZ = transform.position.z;

        //Vector3 newPosition = new Vector3(0, positionY, positionZ);

        //transform.position = newPosition;
    }

   
    public void Shake()
    {
        originalPosition = transform.position;
        InvokeRepeating("DoShake", 0, 0.01f);
        Invoke("StopShake", shakeDuration);
    }

    private void DoShake()
    {
        float shakeX = Random.Range(-1f, 1f) * shakeMagnitude;
        float shakeY = Random.Range(-1f, 1f) * shakeMagnitude;

        transform.position = new Vector3(originalPosition.x + shakeX, originalPosition.y + shakeY, originalPosition.z);
    }

    private void StopShake()
    {
        CancelInvoke("DoShake");
        transform.position = new Vector3(0,0,transform.position.z);
    }

    public IEnumerator ShakeCoroutine()
    {
        Vector3 orignalPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < 0.15f)
        {
            float x = Random.Range(-1f, 1f) * 0.4f;
            float y = Random.Range(-1f, 1f) * 0.4f;

            transform.position += new Vector3(x, y, -10f);
            elapsed += Time.deltaTime;
            yield return 0;
        }
        transform.position = orignalPosition;
    }

    public void ShakeCamera()
    {
        StartCoroutine(ShakeCoroutine());
    }
}