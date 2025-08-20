using UnityEngine;
using System.Collections.Generic;

public class ObjectPool
{
    private GameObject prefab;
    private Transform parent;
    private int size;
    private Queue<GameObject> pool;

    public ObjectPool(GameObject prefab, Transform parent, int size)
    {
        this.prefab = prefab;
        this.parent = parent;
        this.size = size;
        pool = new();
        InitialiseAllObjects(prefab, parent, size);
    }

    public GameObject GetFromPool()
    {
        if (pool.Count > 0)
        {
            GameObject obj = pool.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        return GameObject.Instantiate(prefab);
    }

    public void ReturnToPool(GameObject instance)
    {
        instance.SetActive(false);
        pool.Enqueue(instance);
    }

    private void InitialiseAllObjects(GameObject prefab, Transform parent, int size)
    {
        for (int i = 0; i < size; i++)
        {
            GameObject obj = GameObject.Instantiate(prefab, parent);
            obj.SetActive(false);
            pool.Enqueue(obj);
        }
    }





}
