using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundariesLevel4 : MonoBehaviour
{
    private Vector3 screenBounds;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }


    private void LateUpdate()
    {//Player stay inside this values.
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x-1.75f , screenBounds.x +9);
        viewPos.z = Mathf.Clamp(viewPos.z, screenBounds.z + +12, (screenBounds.z ) * -1);
        transform.position = viewPos;
    }
}
