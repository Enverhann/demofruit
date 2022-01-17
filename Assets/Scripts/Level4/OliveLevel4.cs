using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OliveLevel4 : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private float speed = 20f;
    PlayerController playerController;
    Vector3 start;
    public GameObject player;
    private float extraPad = 1.25f;
    private float extraScale = 1.1f;
    public Animator anim;
    public static event Action FruitCount;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    void Start()
    {
        start = transform.position;
        StartPosition();
    }

    private void StartPosition()
    {
        rb.velocity = Vector3.zero;
        transform.position = start;
        rb.velocity = new Vector3(-speed, 0, -speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Collision effects with fruits.
        if (collision.collider.CompareTag("Watermelon"))
        {
            transform.localScale += new Vector3(extraScale, extraScale, extraScale);
            Destroy(collision.collider.gameObject);
            FruitCount?.Invoke();
            rb.velocity = new Vector3(transform.position.x, 0, rb.velocity.z );
        }
        if (collision.collider.CompareTag("Banana"))
        {
            player.transform.localScale += new Vector3(extraPad, 0, 0);
            Destroy(collision.collider.gameObject);
            FruitCount?.Invoke();
            rb.velocity = new Vector3(transform.position.x, 0, rb.velocity.z );
        }
        if (collision.collider.CompareTag("Cheese"))
        {
            StartCoroutine(Wobble());
            Destroy(collision.collider.gameObject);
            FruitCount?.Invoke();
            rb.velocity = new Vector3(transform.position.x, 0, rb.velocity.z );
        }
        if (collision.collider.CompareTag("Hamburger")&&playerController.reversePlayer==false)
        {
            playerController.reversePlayer = true;
            Destroy(collision.collider.gameObject);
            FruitCount?.Invoke();
            rb.velocity = new Vector3(transform.position.x, 0, rb.velocity.z );
        }
        else if(collision.collider.CompareTag("Hamburger") && playerController.reversePlayer == true)
        {
            playerController.reversePlayer = false;
            Destroy(collision.collider.gameObject);
            FruitCount?.Invoke();
            rb.velocity = new Vector3(transform.position.x, 0, rb.velocity.z );
        }
        if (collision.collider.CompareTag("Cherry"))
        {
            speed = speed * 1.1f;
            Destroy(collision.collider.gameObject);
            FruitCount?.Invoke();
            rb.velocity = new Vector3(transform.position.x, 0, rb.velocity.z);
        }

        //Collision with walls.
        if (collision.collider.CompareTag("BorderRight"))
        {
            rb.velocity = new Vector3(-speed, 0, rb.velocity.z*1.1f);
        }
        if (collision.collider.CompareTag("BorderLeft"))
        {
            rb.velocity = new Vector3(speed, 0, rb.velocity.z);
        }
        if (collision.collider.CompareTag("BorderUp"))
        {
            rb.velocity = new Vector3(-speed, 0, -speed);
        }
    }

    IEnumerator Wobble()
    {
        //Wobble animation.
        anim.SetBool("isWobble", true);
        yield return new WaitForSeconds(5f);
        anim.SetBool("isWobble", false);
    }
}
