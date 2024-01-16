using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneAfterImage : MonoBehaviour
{
    [SerializeField] float activeTime = 0.1f;
    private float timeActivated;
    private float alpha;
    private float alphaSet = 0.8f;
    [SerializeField] float alphaMultiplier = 0.95f;

    private Transform playerPlane;

    private SpriteRenderer spriteRenderer;
    private SpriteRenderer playerspriteRenderer;

    [SerializeField] ObjectPool pool;

    private Color color;

    private void OnEnable()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerPlane = GameObject.FindGameObjectWithTag("Player").transform;
        playerspriteRenderer = playerPlane.GetComponent<SpriteRenderer>();

        alpha = alphaSet;
        spriteRenderer.sprite = playerspriteRenderer.sprite;
        transform.position = playerPlane.position;
        transform.rotation = playerPlane.rotation;
        timeActivated = Time.time;
    }

    private void Update()
    {
        alpha *= alphaMultiplier;
        color = new Color(1f,1f,1f,alpha);
        spriteRenderer.color = color;

        if(Time.time >= (timeActivated + activeTime))
        {
            //ObjectPool.Instance.ReturnObject(gameObject);
        }
    }

}
