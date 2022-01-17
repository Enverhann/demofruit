using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel4 : MonoBehaviour
{
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Olive"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
