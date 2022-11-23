using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingRockController : MonoBehaviour
{
    public Transform rotatingRock;
    public Transform inverseRotatingRock;
    public Transform rotatingRockOutline;
    public Transform inverseRotatingRockOutline;
    public InteractionSpace interactionSpace;

    Quaternion initialRotation;
    //Quaternion secondRotation;
    Quaternion initialInverseRotation;
    //Quaternion secondInverseRotation;
    float speed;

    float rotationNumber;
    float inverseRotationNumber;

    float timer = 0;

    bool isClickOnEnter;
    public bool isRockRotatingFinish;
    // Start is called before the first frame update
    void Start()
    {
        initialRotation = rotatingRock.localRotation;
        initialInverseRotation = inverseRotatingRock.localRotation;
        rotationNumber = -120;
        inverseRotationNumber = 120;
        speed = 0.2f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && interactionSpace.isEnter)
        {
            isClickOnEnter = true;
        }
        if (isClickOnEnter && interactionSpace.isEnter)
        {
            rotatingRock.localRotation = Quaternion.Lerp(initialRotation, Quaternion.Euler(initialRotation.eulerAngles.x, initialRotation.eulerAngles.y, initialRotation.eulerAngles.z + rotationNumber), timer * speed);
            inverseRotatingRock.localRotation = Quaternion.Lerp(initialInverseRotation, Quaternion.Euler(initialInverseRotation.eulerAngles.x, initialInverseRotation.eulerAngles.y, initialInverseRotation.eulerAngles.z + inverseRotationNumber), timer * speed);
            rotatingRockOutline.localRotation = Quaternion.Lerp(initialRotation, Quaternion.Euler(initialRotation.eulerAngles.x, initialRotation.eulerAngles.y, initialRotation.eulerAngles.z + rotationNumber), timer * speed);
            inverseRotatingRockOutline.localRotation = Quaternion.Lerp(initialInverseRotation, Quaternion.Euler(initialInverseRotation.eulerAngles.x, initialInverseRotation.eulerAngles.y, initialInverseRotation.eulerAngles.z + inverseRotationNumber), timer * speed);
            timer += Time.deltaTime;
        }
        if(timer > 1 / speed)
        {
            initialRotation = rotatingRock.localRotation;
            initialInverseRotation = inverseRotatingRock.localRotation;
            rotationNumber = -rotationNumber;
            inverseRotationNumber = -rotationNumber;
            isClickOnEnter = false;
            isRockRotatingFinish = true;
            timer = 0;
        }
    }
    public void RockRotation(Quaternion initialRotation, Quaternion initialInverseRotation, float rotationNumber, float inverseRotationNumber, float timer, float speed)
    {
        rotatingRock.localRotation = Quaternion.Lerp(initialRotation, Quaternion.Euler(initialRotation.eulerAngles.x, initialRotation.eulerAngles.y, initialRotation.eulerAngles.z + rotationNumber), timer * speed);
        inverseRotatingRock.localRotation = Quaternion.Lerp(initialInverseRotation, Quaternion.Euler(initialInverseRotation.eulerAngles.x, initialInverseRotation.eulerAngles.y, initialInverseRotation.eulerAngles.z + inverseRotationNumber), timer * speed);
        rotatingRockOutline.localRotation = Quaternion.Lerp(initialRotation, Quaternion.Euler(initialRotation.eulerAngles.x, initialRotation.eulerAngles.y, initialRotation.eulerAngles.z + rotationNumber), timer * speed);
        inverseRotatingRockOutline.localRotation = Quaternion.Lerp(initialInverseRotation, Quaternion.Euler(initialInverseRotation.eulerAngles.x, initialInverseRotation.eulerAngles.y, initialInverseRotation.eulerAngles.z + inverseRotationNumber), timer * speed);
    }
}
