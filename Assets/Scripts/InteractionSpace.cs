using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSpace : MonoBehaviour
{
    public GameObject rotatingSystem;
    public bool isEnter;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            isEnter = true;
            rotatingSystem.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isEnter = false;
        rotatingSystem.SetActive(false);
    }
}