using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : Buff
{
    [SerializeField] private float _explosionRadius = 2f;
    [SerializeField] private LayerMask _enemiesLayer = 6;
    [SerializeField] private GameObject _explosionParticles;

    protected override void MakeBuffEffect()
    {
        _explosionParticles.transform.parent = null;
        _explosionParticles.SetActive(true);
        var enemies = Physics2D.OverlapCircleAll(transform.position, _explosionRadius, _enemiesLayer);
        foreach(var e in enemies)
        {
            e.GetComponent<Enemy>().EnemyDead();
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, _explosionRadius);
    }
}
