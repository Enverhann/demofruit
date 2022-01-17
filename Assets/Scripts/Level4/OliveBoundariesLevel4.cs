using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OliveBoundariesLevel4 : MonoBehaviour
{
    private Vector3 screenBounds;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }


    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x -2.75f , screenBounds.x +15);
        viewPos.z = Mathf.Clamp(viewPos.z, screenBounds.z + 12, (screenBounds.z - 12) * -1);
        transform.position = viewPos;
    }
}
