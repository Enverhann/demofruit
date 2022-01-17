using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    [SerializeField] private float magneticPull;

    private void OnTriggerStay(Collider other)
    {//Pull olives to banana.
        if (other.CompareTag("Olive"))
        {
            other.attachedRigidbody.AddForce((transform.position - other.transform.position) * magneticPull);
        }
    }
}
