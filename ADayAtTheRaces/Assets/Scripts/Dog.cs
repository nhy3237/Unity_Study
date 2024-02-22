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

        // * 업데이트 문은 안 쓰는 것을 권장 -> 대신 쓸 수 있는 코루틴을 사용해도 됨

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

