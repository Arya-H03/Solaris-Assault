using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{

    [SerializeField] Vector2 parallaxEffectMultiplier;

    private Transform cameraTransform;
    private Vector3 lastCamPos;

    private float textureUnitSizeY;

    // Start is called before the first frame update
    void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCamPos = cameraTransform.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textureUnitSizeY = texture.height / sprite.pixelsPerUnit;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltaMovement = cameraTransform.position - lastCamPos;
        transform.position += new Vector3(deltaMovement.x * parallaxEffectMultiplier.x, deltaMovement.y * parallaxEffectMultiplier.y, deltaMovement.z);
        lastCamPos = cameraTransform.position;

        if(cameraTransform.position.y - transform.position.y >= textureUnitSizeY)
        {
            float offsetPosY = (cameraTransform.position.y - transform.position.y) % textureUnitSizeY;
            transform.position = new Vector3(cameraTransform.position.y + offsetPosY, transform.position.y);
        }
    }
}
