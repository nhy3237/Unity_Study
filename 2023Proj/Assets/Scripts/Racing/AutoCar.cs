using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoCar : MonoBehaviour
{
    public float rotationSpeed = 100.0f;
    public float moveSpeed = 5.0f;

    public float finishDistanceThreshold = 100;

    void Update()
    {
        AutoMove();
    }

    void AutoMove()
    {
        float moveDelta = this.moveSpeed * Time.deltaTime;
        this.transform.Translate(Vector3.forward * moveDelta);
    }
}