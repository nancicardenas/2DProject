using UnityEngine;
using System.Collections.Generic;
public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling SharedInstance;
    public List<GameObject> pooledObjects;
    public GameObject objectToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this;
    }

    void Start()
    {
        //this list will hold the instantiated ground items 
        pooledObjects = new List<GameObject>();
        GameObject temp;

        //instantiates the ground to a certain amount of times and sets it as inactive state before adding them into the pooledObjects list
        for(int i = 0; i < amountToPool; i++)
        {
            temp = Instantiate(objectToPool);
            temp.SetActive(false);
            pooledObjects.Add(temp);
        }
    }

    public GameObject GetPooledObject()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }

        }

        return null;
    }
}
