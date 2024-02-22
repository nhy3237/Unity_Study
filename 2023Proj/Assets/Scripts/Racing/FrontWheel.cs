using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontWheel : MonoBehaviour
{
    public float maxRotationAngleY = 45.0f;
    public float rotationSpeed = 100.0f;
    public float moveSpeed = 5.0f;

    private float currentRotationAngleX = 0.0f;
    private float currentRotationAngleY = 0.0f;

    void Update()
    {
        WheelMove();
    }

    void WheelMove()
    {
        float move = Input.GetAxis("Vertical");
        float rotation = Input.GetAxis("Horizontal");

        currentRotationAngleX += rotationSpeed * Time.deltaTime * move;

        if (rotation == 0 && move != 0)
        {
            if (currentRotationAngleY > 0)
                currentRotationAngleY -= rotationSpeed * Time.deltaTime;
            else
                currentRotationAngleY += rotationSpeed * Time.deltaTime;
        }
        else currentRotationAngleY += rotationSpeed * Time.deltaTime * rotation;
        currentRotationAngleY = Mathf.Clamp(currentRotationAngleY, -maxRotationAngleY, maxRotationAngleY);
        transform.localRotation = Quaternion.Euler(currentRotationAngleX, currentRotationAngleY, 0.0f);
    }
}
