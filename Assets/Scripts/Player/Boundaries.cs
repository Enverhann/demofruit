using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    private Vector3 screenBounds;
    
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    
    private void LateUpdate()
    {//Player stay inside this values.
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x-2, screenBounds.x * -1);
        viewPos.z = Mathf.Clamp(viewPos.z, screenBounds.z+24, (screenBounds.z + -11) * -1);
        transform.position = viewPos;
    }
}
