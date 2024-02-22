using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Animation spartanKing;
    public GameObject objSword = null;

    public Transform[] walls;
    public float moveSpeed = 3.0f;

    private Transform nearestWall;


    void Start()
    {
        spartanKing = gameObject.GetComponentInChildren<Animation>();
        objSword.SetActive(false);
    }

    void Update()
    {
        FindNearestWall();

        if (nearestWall != null)
        {
            // 적 캐릭터를 가장 가까운 벽 쪽으로 이동시킵니다.
            Vector3 direction = (nearestWall.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime, Space.World);

            // 적 캐릭터가 벽을 바라보도록 회전시킵니다.
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, moveSpeed * Time.deltaTime);

            spartanKing.Play("run");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Sword")
        {
            spartanKing.Play("diehard");
        }
    }
    // 가장 가까운 벽을 찾는 함수
    private void FindNearestWall()
    {
        float minDistance = float.MaxValue;

        foreach (Transform wall in walls)
        {
            float distance = Vector3.Distance(transform.position, wall.position);

            if (distance < minDistance)
            {
                minDistance = distance;
                nearestWall = wall;
            }
        }
    }

}