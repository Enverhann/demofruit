using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Collide : MonoBehaviour
{
    public GameObject prefab;
    public static event Action OliveCount;
    Vector3 rotation = new Vector3(0, 0, 0);

    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //With instance ID we can call OnCollisionEnter once instead of twice.
        Collide collide = collision.collider.GetComponent<Collide>();
        if (collide != null && collide.GetInstanceID() > GetInstanceID() && collision.collider.CompareTag("Olive") && collision.collider.CompareTag("Olive"))
        {  
            Destroy(collision.collider.gameObject);
            Destroy(gameObject);
            Instantiate(prefab, transform.position, Quaternion.identity);
            OliveCount?.Invoke();
        }
        if (collide != null && collide.GetInstanceID() > GetInstanceID() && collision.collider.CompareTag("Cherry") && collision.collider.CompareTag("Cherry"))
        {
            Destroy(collision.collider.gameObject);
            Destroy(gameObject);
            Instantiate(prefab, transform.position, Quaternion.identity);
            OliveCount?.Invoke();
        }
        if (collide != null && collide.GetInstanceID() > GetInstanceID() && collision.collider.CompareTag("Banana") && collision.collider.CompareTag("Banana"))
        {
            Destroy(collision.collider.gameObject);
            Destroy(gameObject);
            Instantiate(prefab, transform.position, Quaternion.identity);
            OliveCount?.Invoke();
        }
        if (collide != null && collide.GetInstanceID() > GetInstanceID() && collision.collider.CompareTag("Hotdog") && collision.collider.CompareTag("Hotdog"))
        {
            Destroy(collision.collider.gameObject);
            Destroy(gameObject);
            Instantiate(prefab, transform.position, Quaternion.identity);
            OliveCount?.Invoke();
        }
        if (collide != null && collide.GetInstanceID() > GetInstanceID() && collision.collider.CompareTag("Hamburger") && collision.collider.CompareTag("Hamburger"))
        {
            Destroy(collision.collider.gameObject);
            Destroy(gameObject);
            Instantiate(prefab, transform.position, Quaternion.identity);
            OliveCount?.Invoke();
        }
        if (collision.collider.CompareTag("Cheese") && collision.collider.CompareTag("Cheese") && collide != null)
        {
            Destroy(collision.collider.gameObject);
            Destroy(this.gameObject);
            Instantiate(prefab, transform.position, Quaternion.identity);
            OliveCount?.Invoke();
        }
    }
}
