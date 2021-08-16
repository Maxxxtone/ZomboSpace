using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            MakeBuffEffect();
            Destroy(gameObject);
        }
    }
    protected virtual void MakeBuffEffect()
    {
        print("Buff");
    }
}
