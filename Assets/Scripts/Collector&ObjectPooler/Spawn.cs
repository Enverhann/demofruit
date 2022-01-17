using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    ObjectPooler objectPool;

    public void Start()
    {
        objectPool = ObjectPooler.Instance;
    }

    void FixedUpdate()
    {
        objectPool.SpawnFromPool("Cube", transform.position, Quaternion.identity);
    }
}
