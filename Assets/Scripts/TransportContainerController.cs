using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportContainerController : MonoBehaviour
{
    public GameObject openTC;
    public GameObject topOutlineTC;
    public GameObject topTC;
    public bool isReturn;
    private float timeCount;
    public FirstPersonController firstPersonController;
    Quaternion initialRot;
    Quaternion nextRot;
    Quaternion currentRot;
    // Start is called before the first frame update
    void Start()
    {
        initialRot = Quaternion.Euler(0, -90, 0);
        nextRot = Quaternion.Euler(0, 0, 0);
        currentRot = initialRot;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            isReturn = true;
            timeCount = 0;
        }
        if (openTC.activeSelf && isReturn)
        {
            topTC.transform.localRotation = Quaternion.Lerp(topTC.transform.localRotation, currentRot, timeCount * 0.1f);
            topOutlineTC.transform.localRotation = Quaternion.Lerp(topOutlineTC.transform.localRotation, currentRot, timeCount * 0.1f);
            timeCount += Time.deltaTime;
        }
        if(timeCount > 1)
        {
            timeCount = 0;
            isReturn = false;
            if(currentRot == initialRot)
            {
                currentRot = nextRot;
            }
            else
            {
                currentRot = initialRot;
            }
        }
       /* else
        {
            topTC.transform.localRotation = Quaternion.Lerp(topTC.transform.localRotation, Quaternion.Euler(0, 0, 0), timeCount);
            timeCount = +Time.deltaTime;
        }*/
       /* if(firstPersonController.distance > 2 && topTC.transform.localRotation == Quaternion.Euler(0, 0, 0))
        {
            isReturn = false;
        }*/
    }
}
