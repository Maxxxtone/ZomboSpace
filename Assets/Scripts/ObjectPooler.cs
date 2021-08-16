using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int countOfObjects;
    }
    public static ObjectPooler instance;
    public bool spawning;
    [SerializeField] private List<Pool> _pools;
    private Dictionary<string, Queue<GameObject>> _poolsDictionary;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        spawning = true;
        _poolsDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (var pool in _pools)
        {
            var objectsQueue = new Queue<GameObject>();
            for (int i = 0; i < pool.countOfObjects; i++)
            {
                var pooledObject = Instantiate(pool.prefab);
                pooledObject.SetActive(false);
                objectsQueue.Enqueue(pooledObject);
            }
            _poolsDictionary.Add(pool.tag, objectsQueue);
        }
    }
    public GameObject SpawnObjectFromQueue(string tag, Vector2 position, Quaternion rotation)
    {
        if (spawning)
        {
            var spawningObject = _poolsDictionary[tag].Dequeue();
            _poolsDictionary[tag].Enqueue(spawningObject);
            if (!spawningObject.activeSelf)
            {
                spawningObject.SetActive(true);
                spawningObject.transform.position = position;
                spawningObject.transform.rotation = rotation;
                return spawningObject;
            }
        }
        return null;
    }
}
