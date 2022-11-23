using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    public Transform player;
    public Image fade;
    public float alpha;
    float tempDistance;
    // Start is called before the first frame update
    void Start()
    {

        //alpha = fade.GetComponent<Image>();
        //tempDistance = 2;

    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if(distance < 2)
        {
            fade.color = new Color(0f, 0f, 0f, 1 - distance);
        }
        if(distance < 0)
        {
            fade.color = new Color(0f, 0f, 0f, 1f);
        }
    }
}
