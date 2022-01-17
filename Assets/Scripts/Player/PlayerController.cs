using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] float speed = default;
    private Vector3 direction;
    Vector2 firstPos, targetPos;
    [SerializeField] RectTransform rect = default;
    [SerializeField] private float rotationX;
    [SerializeField] private float rotationZ;
    [SerializeField] private float extraRotationY;
    [SerializeField] private bool rotatePlayer;
    public bool reversePlayer;
    public float extraPad=0;

    void Initialized()
    {
        EventManager.PointerDragged += Move;
        EventManager.PointerUpped += Stop;
        EventManager.PointerDowned += Touch;
    }
    public void OnDisable()
    {
        EventManager.PointerDragged -= Move;
        EventManager.PointerUpped -= Stop;
        EventManager.PointerDowned -= Touch;
    }

    private void Awake()
    {
        Initialized();
        rb = GetComponent<Rigidbody>();
    }

    public void Move(PointerEventData pointerEventData)
    {
        //Player movement with event.
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, pointerEventData.position, pointerEventData.pressEventCamera, out targetPos);
        if (reversePlayer) { 
            Vector2 dragPos = -targetPos + firstPos;   
            direction = new Vector3(dragPos.x / Screen.width, 0, dragPos.y / Screen.height);
        }
        else
        {
            Vector2 dragPos = targetPos - firstPos;
            direction = new Vector3(dragPos.x / Screen.width, 0, dragPos.y / Screen.height);
        }
        if (pointerEventData.dragging)
        {
            rb.velocity = direction * speed;

            if (rotatePlayer)
            {
                float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Euler(rotationX, targetAngle + extraRotationY, rotationZ);
            }
        }
    }

    public void Stop(PointerEventData pointerEventData)
    {
        rb.velocity = Vector3.zero;
    }

    public void Touch(PointerEventData pointerEventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, pointerEventData.position, pointerEventData.pressEventCamera, out firstPos);
    }
}
