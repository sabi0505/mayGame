using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling<T> : MonoBehaviour
{
    protected Queue<T> _poolingObjects;

    private void Awake()
    {
        _poolingObjects = new Queue<T>();

        for (int i = 0; i < transform.childCount; i++)
        {
            T p = transform.GetChild(i).GetComponent<T>();

            if (p == null)
                continue;

            _poolingObjects.Enqueue(p);
        }
    }

    public T SpawnObject()
    {
        T p = _poolingObjects.Dequeue();
        return p;
    }

    public void ReturnObject(T p)
    {
        _poolingObjects.Enqueue(p);
    }
}
