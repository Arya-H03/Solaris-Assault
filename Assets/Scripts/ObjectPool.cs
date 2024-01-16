using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject objectPrefab;
    [SerializeField] int numberOfItems;

    private Queue<GameObject> availableObjects = new Queue<GameObject>();
   
    //public static ObjectPool Instance { get; private set; }

    private void Awake()
    {
        //Instance = this;
        for(int i = 0; i < numberOfItems; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.transform.SetParent(transform);
            availableObjects.Enqueue(obj);  
            obj.SetActive(false);


        }
    }

    public GameObject GetObject(bool isSet, Vector3 poistion, Vector3 rotation)
    {

        if (availableObjects.Count > 0)
        {
            GameObject obj = availableObjects.Dequeue();
            obj.SetActive(true);
            if (isSet == true)
            {
                obj.transform.localPosition = poistion;
                obj.transform.eulerAngles = rotation;
            }
            return obj;
        }
        else
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.transform.SetParent(transform);
            if (isSet == true)
            {
                obj.transform.localPosition = poistion;
                obj.transform.eulerAngles = rotation;
            }
            return obj;
        }

        //var obj = availableObjects.Dequeue();
        //obj.SetActive(true);
        //if (isSet == true)
        //{
        //    obj.transform.localPosition = poistion;
        //    obj.transform.eulerAngles = rotation;
        //}


    }

    public void ReturnObject(GameObject obj)
    {
        availableObjects.Enqueue(obj);
        obj.SetActive(false);
    }


    //private void GenerateNewObjects()
    //{
        
    //        var obj = Instantiate(objectPrefab);
    //        obj.transform.SetParent(transform);
    //        ReturnObject(obj);
           


        
       
    //}

    private void GenerateNewObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var obj = Instantiate(objectPrefab);
            obj.gameObject.SetActive(false);
            obj.transform.SetParent(transform);
            availableObjects.Enqueue(obj);
        }
    }

}
