using System;
using UnityEngine;
using UnityEngine.Pool;

public class Pool : MonoBehaviour
{
    [SerializeField] int maxPoolSize;
    [SerializeField] int size;
    [SerializeField] GameObject preFab;
    [SerializeField] int CountActive;
    [SerializeField] int CountAll;
    [SerializeField] int CountInactive;
    public ObjectPool<GameObject> pool;

    void Start()
    {
        pool = new ObjectPool<GameObject>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, size, maxPoolSize);
    }

    void Update()
    {
        pool.Get().transform.position = Vector2.zero;
        CountActive = pool.CountActive;
        CountAll = pool.CountAll;
        CountInactive = pool.CountInactive;
    }

    private GameObject CreatePooledItem()
    {
        GameObject obj = GameObject.Instantiate(preFab);
        obj.transform.parent = transform;
        return obj;
    }

    private void OnTakeFromPool(GameObject obj)
    {
        obj.SetActive(true);
    }

    private void OnReturnedToPool(GameObject obj)
    {
        obj.SetActive(false);
    }

    private void OnDestroyPoolObject(GameObject obj)
    {
        GameObject.Destroy(obj);
    }
}
