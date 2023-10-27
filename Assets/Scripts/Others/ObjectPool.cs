using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool
{
    private static ObjectPool instance;
    private Dictionary<string, Queue<GameObject>> objectPool = new Dictionary<string, Queue<GameObject>>();
    private GameObject pool;
    public static ObjectPool Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new ObjectPool();
            }
            return instance;
        }
    }

    public GameObject GetObject(GameObject prefab)
    {
        GameObject _object;
        if (!objectPool.ContainsKey(prefab.name) || objectPool[prefab.name].Count == 0)
        {
            _object = GameObject.Instantiate(prefab);
            PushObject(_object);
            if (pool == null)
            {
                pool = new GameObject("ObjectPool");
            }
            GameObject child = GameObject.Find(prefab.name);
            if (!child)
            {
                child = new GameObject(prefab.name);
                child.transform.parent = pool.transform;
            }
            _object.transform.SetParent(child.transform);
        }
        _object = objectPool[prefab.name].Dequeue();
        _object.SetActive(true);
        return _object;     
    }

    public void PushObject(GameObject prefab)
    {
        string _name = prefab.name.Replace("(Clone)", string.Empty);
        if (!objectPool.ContainsKey(_name))
        {
            objectPool.Add(_name, new Queue<GameObject>());
        }
        objectPool[_name].Enqueue(prefab);
        prefab.SetActive(false);
    }

    public void Clear()
    {
        // 遍历对象池中的所有队列，销毁队列中的对象
        foreach (var queue in objectPool.Values)
        {
            foreach (var obj in queue)
            {
                GameObject.Destroy(obj);
            }
        }

        // 清空对象池字典
        objectPool.Clear();

        // 销毁对象池的父对象
        if (pool != null)
        {
            GameObject.Destroy(pool);
            pool = null;
        }
    }

}
