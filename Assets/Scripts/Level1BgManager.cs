using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1BgManager : MonoBehaviour
{
    [SerializeField] GameObject image1;
    [SerializeField] GameObject image2;
    private GameObject currentImage;
    private GameObject secondaryImage;
    private GameObject helpImage;
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        currentImage = image1;
        secondaryImage = image2;    
    }

    // Update is called once per frame -14 -33
    void Update()
    {
        if(currentImage.transform.position.y <= -30)
        {
            helpImage = currentImage;
            currentImage.transform.position = secondaryImage.transform.position + new Vector3(0, 31.25f, 0);
            currentImage = secondaryImage;
            secondaryImage = helpImage;
        }

        image1.transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;
        image2.transform.position += new Vector3(0, -1, 0) * speed * Time.deltaTime;
    }
}
