using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy3D : MonoBehaviour
{
    public GameObject target;
    NavMeshAgent agent = null;
    Animator animator;

    private float attackDistance = 2.0f;

    void Start()
    {
        agent = GetComponentInChildren<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        agent.SetDestination(target.transform.position);
        animator.SetFloat("Speed", agent.velocity.magnitude);

        float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

        if (animator.GetCurrentAnimatorStateInfo(1).IsName("Upperbody.Idle") 
            && distanceToTarget <= attackDistance
            && !animator.GetBool("bDamage"))
        {
            animator.SetTrigger("Attack");
        }
    }

    private void OnDrawGizmos()
    {
        if (agent != null)
        {
            NavMeshPath path = agent.path;

            Gizmos.color = Color.blue;
            foreach (Vector3 corner in path.corners)
            {
                Gizmos.DrawSphere(corner, 0.4f);
            }

            Gizmos.color = Color.red;
            Vector3 pos = transform.position;
            foreach (Vector3 corner in path.corners)
            {
                Gizmos.DrawLine(pos, corner);
                pos = corner;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Weapon"))
        {
            animator.SetBool("bDamage", true);
            StartCoroutine("Damage_Routine");
        }
    }

    IEnumerator Damage_Routine()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            if (animator.GetBool("bDamage") == true && animator.GetCurrentAnimatorStateInfo(1).IsName("Upperbody.Damage"))
            {
                if (animator.GetCurrentAnimatorStateInfo(1).normalizedTime >= 0.9f)
                {
                    animator.SetBool("bDamage", false);
                    break;
                }
            }
        }
    }
}
