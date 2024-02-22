using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RearWheel : MonoBehaviour
{
    public float rotationSpeed = 100.0f;
    public float moveSpeed = 5.0f;

    void Update()
    {
        WheelMove();
    }

    void WheelMove()
    {
        float move = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * move);

       // transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * move);
    }
}
