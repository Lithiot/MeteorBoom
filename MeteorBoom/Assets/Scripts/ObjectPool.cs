using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour {

    [SerializeField] private GameObject objectToPool;
    [SerializeField] private bool willGrow;
    [SerializeField] private int initialSize = 3;
    private List<GameObject> objectPool;

    private void Start()
    {
        objectPool = new List<GameObject>();

        for (int i = 0; i < initialSize; i++)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }

    public GameObject GetObjectFromPool()
    {
        for (int i = 0; i < objectPool.Count; i++)
        {
            if (!objectPool[i].activeInHierarchy)
            {
                return objectPool[i];
            }
        }

        if (willGrow)
        {
            GameObject obj = (GameObject)Instantiate(objectToPool);
            obj.SetActive(false);
            objectPool.Add(obj);
            return obj;
        }

        return null;
    }

}