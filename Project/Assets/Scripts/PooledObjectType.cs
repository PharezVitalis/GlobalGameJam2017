using UnityEngine;
using System.Collections;



public class PooledObjectType
{
    GameObject[] pooledObj;
    

     
    public PooledObjectType(GameObject type, int size)
    {
        pooledObj = new GameObject[size];

        for (int i = 0; i < pooledObj.Length;i++)
        {
            pooledObj[i] = GameObject.Instantiate(type);
            pooledObj[i].SetActive(false);
        }
    }

    public GameObject GetPooled()
    {

        for (int i = 0; i< pooledObj.Length; i++)
        {
            if (!pooledObj[i].activeInHierarchy) return pooledObj[i];
        }

        return null;
    }


}

