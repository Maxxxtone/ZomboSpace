using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    [SerializeField] Vector2 _leftUpPoint, _rightDownPoint, _leftDownPoint, _rightUpPoint;
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(_leftUpPoint, _rightUpPoint);
        Gizmos.DrawLine(_leftUpPoint, _leftDownPoint);
        Gizmos.DrawLine(_leftDownPoint, _rightDownPoint);
        Gizmos.DrawLine(_rightDownPoint, _rightUpPoint);
        Gizmos.color = Color.red;
    }
    public Vector2 GetPositionToSpawn()
    {
        var x = Random.Range(_leftUpPoint.x, _rightUpPoint.x);
        var y = Random.Range(_leftUpPoint.y, _leftDownPoint.y);
        return new Vector2(x, y);
    }
}
