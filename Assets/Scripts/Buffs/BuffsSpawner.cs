using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffsSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _buffsObjects;
    [SerializeField] private SpawnZone _spawnZone;
    [SerializeField] private float _spawnRateMin = 3f, _spawnRateMax = 6f;
    private float _timer;
    private bool _spawning;
    private void Start()
    {
        _timer = Random.Range(_spawnRateMin, _spawnRateMax);
        _spawning = true;
        Hero.instance.OnHeroDead += StopSpawning;
    }
    private void Update()
    {
        if (_spawning)
        {
            if (_timer <= 0)
            {
                var index = Random.Range(0, _buffsObjects.Length);
                Instantiate(_buffsObjects[index], _spawnZone.GetPositionToSpawn(), Quaternion.identity);
                _timer = Random.Range(_spawnRateMin, _spawnRateMax);
            }
            else
                _timer -= Time.deltaTime;
        }
    }
    protected void StopSpawning() => _spawning = false;
}
