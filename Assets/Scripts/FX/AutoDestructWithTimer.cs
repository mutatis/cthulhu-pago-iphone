// Auto destruct script that can be added to the root particle system
// of a particle effect. It will destroy the gameobject and its children.
using System;
using System.Collections;
using UnityEngine;

public class AutoDestructWithTimer : MonoBehaviour
{
    public float lifespan = 5;   // So you can easily adjust in the inspector

    public IEnumerator OnSpawned()  // Might be able to make this private and still work?
    {
        Rigidbody2D[] rigidbodys = GetComponentsInChildren<Rigidbody2D>();
        for (int i = 0; i < rigidbodys.Length;i++)
        {
            rigidbodys[i].transform.localPosition = Vector3.zero;
        }

        yield return new WaitForSeconds(lifespan);
        TimedDespawn();
    }

    private void TimedDespawn()
    {
        PoolManager.Pools["props"].Despawn(this.transform);
    }
}