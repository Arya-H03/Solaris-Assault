using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControlLevel01 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShakeCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator ShakeCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.2f);
            Vector3 orignalPosition = transform.position;
            float elapsed = 0f;

            while (elapsed < 0.15f)
            {
                float x = Random.Range(-0.1f, 0.1f) * 0.01f;
                float y = Random.Range(-0.1f, 0.1f) * 0.01f;

                transform.position += new Vector3(x, y, 0f);
                elapsed += Time.deltaTime;
                yield return 0;
            }
            transform.position = orignalPosition;
        }
    }
}
