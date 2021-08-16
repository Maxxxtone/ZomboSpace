using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : Spawner
{
    protected override void SpawnObject(Vector2 position, Quaternion rotation)
    {
        base.SpawnObject(position, rotation);
    }
    private void Update()
    {
        if (_currentTimer <= 0)
        {
            SpawnObject(_spawnZone.GetPositionToSpawn(), Quaternion.identity);
            _currentTimer = _spawnRate;
        }
        else
            _currentTimer -= Time.deltaTime;
    }
}
