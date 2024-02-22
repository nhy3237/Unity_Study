using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Lab1
{
    public class Dog : MonoBehaviour
    {
        [SerializeField]
        int id = 0;

        Rigidbody rigidbody;
        bool isRunning = false;

        // Start is called before the first frame update
        void Start()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        // * ������Ʈ ���� �� ���� ���� ���� -> ��� �� �� �ִ� �ڷ�ƾ�� ����ص� ��

        public void Run()
        {
            float duration = Random.Range(0.1f, 1.1f);
            Debug.Log("duration : " + duration);

            isRunning = true;
            StartCoroutine(Running(duration));
        }

        public void Stop()
        {
            isRunning = false;
        }

        IEnumerator Running(float duration)
        {
            while(isRunning)
            {            
                int velocity = Random.Range(100, 1000);
                Debug.Log("velocity : " + velocity);

                rigidbody.AddForce(new Vector3(velocity, 0, 0));
                //rigidbody.velocity *= duration;

                yield return new WaitForSeconds(duration);
            }
        }
    } 
}

