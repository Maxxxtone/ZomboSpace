using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] protected float _spawnRate;
    [SerializeField] protected GameObject _prefab;
    [SerializeField] protected string _poolTag;
    [SerializeField] protected SpawnZone _spawnZone;
    protected ObjectPooler _objectPooler;
    protected float _currentTimer;
    protected bool _spawning;

    protected virtual void Start()
    {
        _objectPooler = ObjectPooler.instance;
        _spawning = true;
    }
    protected void OnEnable()
    {
        Hero.instance.OnHeroDead += StopSpawning;
    }
    protected virtual void SpawnObject(Vector2 position, Quaternion rotation)
    {
        if(_spawning)
            _objectPooler.SpawnObjectFromQueue(_poolTag, position, rotation);
    }
    protected void StopSpawning() => _spawning = false;
}
