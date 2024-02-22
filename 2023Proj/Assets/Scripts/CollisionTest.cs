using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    float speedMove = 10.0f;
    float speedRotate = 200.0f;
    Rigidbody rigidbody;

    void Start()
    {
        rigidbody = this.gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        float rot = Input.GetAxis("Horizontal");
        float mov = Input.GetAxis("Vertical");

        rot = rot * speedRotate * Time.deltaTime;
        mov = mov * speedMove * Time.deltaTime;

        this.gameObject.transform.Rotate(Vector3.up * rot);
        this.gameObject.transform.Translate(Vector3.forward * mov);

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        print("Collider �浹 " + hitObject.name + "�� �浹����");
    }

    private void OnCollisionStay(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        print("Collider �浹 " + hitObject.name + "�� �浹 �� ~ing");
    }

    private void OnCollisionExit(Collision collision)
    {
        GameObject hitObject = collision.gameObject;
        print("Collider �浹 " + hitObject.name + "�� �浹 ��");
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject hitObject = other.gameObject;
        print("Trigger �浹 " + hitObject.name + "�� �浹����");
    }

    private void OnTriggerStay(Collider other)
    {
        GameObject hitObject = other.gameObject;
        print("Trigger �浹 " + hitObject.name + "�� �浹 �� ~ing");
    }

    private void OnTriggerExit(Collider other)
    {
        GameObject hitObject = other.gameObject;
        print("Trigger �浹 " + hitObject.name + "�� �浹 ��");
    }
}
