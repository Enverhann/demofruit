using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OliveBoundaries : MonoBehaviour
{
    private Vector3 screenBounds;
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }


    private void LateUpdate()
    {
        //Olives stay inside this values.
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x -2.75f, (screenBounds.x-1) * -1);
        viewPos.z = Mathf.Clamp(viewPos.z, screenBounds.z+12 , (screenBounds.z -12 ) * -1);
        transform.position = viewPos;
    }
}
