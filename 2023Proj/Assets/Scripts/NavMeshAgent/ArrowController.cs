using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float rotationSpeed = 5.0f;

    void Update()
    {
        GameObject item = GameObject.FindGameObjectWithTag("Item");
        if (item != null)
        {
            Vector3 direction = item.transform.position - transform.position;

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }
}