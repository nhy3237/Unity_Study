using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        //this.transform.position = new Vector3(0.0f, 5.0f, 0.0f); // ���� ��ǥ ���� ( ���� ���� ), �� ��ġ ��ų �� ���
        this.transform.Translate(new Vector3(0.0f, 0.0f, 0.0f)); // ���� ��ǥ ���� ( ���� ��ǥ + )
    }

    // Update is called once per frame
    void Update()
    {
        //Move_1();
        //Move_2();
        Move_Control();
    }

    void Move_Control()
    {
        //Input.GetKey
        float move = Input.GetAxis("Vertical"); // project setting -> Input Manager
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed * move); // move Ű�� �� ������ �� 0
    }
    void Move_1()
    {
        // delat time : ���� ������Ʈ���� �ɸ��� �ð�, ������ �����ϱ� ���ؼ�
        // ������ ���� �� �ϸ� ��ǻ�͸��� ������ �ӵ��� �޶���
        float moveDelta = this.moveSpeed * Time.deltaTime; 
        Vector3 pos = this.transform.position;
        pos.z += moveDelta;
        this.transform.position = pos;
    }

    void Move_2()
    {
        float moveDelta = this.moveSpeed * Time.deltaTime; 
        this.transform.Translate(Vector3.forward * moveDelta);
    }
}
