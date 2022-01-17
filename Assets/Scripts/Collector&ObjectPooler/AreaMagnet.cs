using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AreaMagnet : MonoBehaviour
{
    [SerializeField] private float magneticPull = default;
    public static event Action OliveEntered;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Olive"))
        {
            other.gameObject.layer = 9;
            other.attachedRigidbody.velocity=(transform.position-other.transform.position)* magneticPull;
            other.gameObject.GetComponent<MeshRenderer>().material.color = Color.yellow;
            OliveEntered?.Invoke();
        }
    }
}
