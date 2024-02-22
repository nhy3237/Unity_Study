using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Car : MonoBehaviour
{
    public float rotationSpeed = 100.0f;
    public float moveSpeed = 5.0f;

    public float finishDistanceThreshold = 100;
    private int cntFinish = 0;

    public Text displayText;

    void Start()
    {
        displayText.text = "0/3";
    }
    void Update()
    {
        Move_1();
    }

    void Move_1()
    {
        float move = Input.GetAxis("Vertical");
        float rotation = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime * move);
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * rotation);
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject hitObject = other.gameObject;

        cntFinish++;
        displayText.text = $"{cntFinish - 1}/3";
    }
}