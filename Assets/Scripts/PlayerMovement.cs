using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight = 3f;

    public GameObject tc;
    public GameObject openTC;
    public float distance;
    public bool isBlock = false;
    Vector3 initialPos;
    float timer;
    float secondtimer;
    float offsetTimer;
    float speedRotation;
    float speedFade;
    public GameObject portal;
    public RotatingRockController rotatingRockController;
    public Image fade;
    public InteractionSpace interactionSpace;
    public Transform inverseInteractionSpace;
    Quaternion rockPos;
    Quaternion inverseRockPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        distance = Vector3.Distance(tc.transform.position, transform.position);
        if (distance < 2)
        {
            openTC.SetActive(true);
        }
        else
        {
            openTC.SetActive(false);
        }

        if (interactionSpace.isEnter && Input.GetKeyDown(KeyCode.Return))
        {
            isBlock = true;
        }
        if (!isBlock)
        {
            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;

            controller.Move(velocity * Time.deltaTime);
        }
        if (isBlock && rotatingRockController.isRockRotatingFinish)
        {
            offsetTimer += Time.deltaTime;
            portal.SetActive(true);
            controller.enabled = false;
            if (offsetTimer > 1.8f)
            {
                Debug.Log("ok");
                transform.position = Vector3.Lerp(transform.position, inverseInteractionSpace.position, timer * speedRotation);
                var t = Mathf.Lerp(0, 1, timer * speedFade);
                fade.color = new Color(0, 0, 0, t);
                timer += Time.deltaTime;
                secondtimer = 0;
                rockPos = rotatingRockController.rotatingRock.localRotation;
                inverseRockPos = rotatingRockController.inverseRotatingRock.localRotation;
            }
        }
        if (timer > 1 / 0.1f)
        {
            controller.enabled = true;
            offsetTimer = 0;
            isBlock = false;
            secondtimer += Time.deltaTime;
            //Debug.Log(secondtimer);
            var t = Mathf.Lerp(0, 1, secondtimer * speedFade);
            fade.color = new Color(0, 0, 0, 1 - t);
            rotatingRockController.RockRotation(rockPos, inverseRockPos, 120, -120, secondtimer, 0.2f);
        }
        if (secondtimer > 1 / 0.2f)
        {
            timer = 0;
            secondtimer = 0;
            portal.SetActive(false);
        }

    }
}
