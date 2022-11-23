using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject rockOutline;
    public GameObject inverseRockOutline;
    public GameObject boxOutline;
    public GameObject gunOutline;
    public TransportContainerController transportContainerController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(transform.position, ray.direction * 10, Color.red);
        RaycastHit hitData;
        if (Physics.Raycast(ray, out hitData))
        {
            //Debug.Log("ok");
            if (hitData.collider.CompareTag("Rock"))
            {
                rockOutline.SetActive(true);
                inverseRockOutline.SetActive(true);
            }
            else if (hitData.collider.CompareTag("Box"))
            {
                boxOutline.SetActive(true);
            }
            else if (hitData.collider.CompareTag("Gun"))
            {
                gunOutline.SetActive(true);
            }
            else
            {
                rockOutline.SetActive(false);
                boxOutline.SetActive(false);
                inverseRockOutline.SetActive(false);
                gunOutline.SetActive(false);
            }
            if(transportContainerController.isReturn)
            {
                boxOutline.SetActive(false);
            }
            // The Ray hit something!
        }
    }
}
