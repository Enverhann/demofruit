using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject olive;
    public GameObject spawner;
    void Awake()
    {
        CreateOlives(64);
    }

    public void CreateOlives(int olivesNum)
    {
        for(int i = 0; i < olivesNum; i++)
        {//Level 1 spawn 64 olives in boundaries and random positions.
            float x = Random.Range(-7.25f, 5.5f);
            float z = Random.Range(-0.5f, 35.75f);
            GameObject oliveClone = Instantiate(olive, new Vector3(x, 0.55f, z), olive.transform.rotation);
            oliveClone.transform.parent = spawner.transform;
        }
    }
}
