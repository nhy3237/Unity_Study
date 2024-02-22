using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MecanimControl : MonoBehaviour
{
    public float runSpeed = 5.0f;
    public float rotationSpeed = 360.0f;

    CharacterController pcController;
    Vector3 direction;

    Animator animator;

    public bool bAttack = false;
    public bool bRun = false;

    void Start()
    {
        pcController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        CharacterControll_Slerp();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            bRun = true;
            animator.SetBool("bRun", bRun);
            animator.ResetTrigger("Damage");
            animator.ResetTrigger("Attack");
            runSpeed = 10.0f;
        }
        else
        {
            bRun = false;
            animator.SetBool("bRun", bRun);
            runSpeed = 5.0f;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            animator.ResetTrigger("Attack");
            animator.SetTrigger("Damage");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            animator.ResetTrigger("Damage");
            animator.SetTrigger("Attack");
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {

        }
    }

    private void CharacterControll_Slerp()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp(transform.forward, direction, rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction));

            transform.LookAt(transform.position + forward);

            animator.ResetTrigger("Damage");
            animator.ResetTrigger("Attack");
        }

        animator.SetFloat("Speed", pcController.velocity.magnitude);
        pcController.Move(direction * runSpeed * Time.deltaTime + Physics.gravity * Time.deltaTime);
    }

    private void Input_Animation()
    {
        if (Input.GetMouseButtonDown(0) && !bAttack)
        {
            bAttack = true;
            animator.SetBool("bAttack", bAttack);
            StartCoroutine("Attack_Routine");
        }
    }

    IEnumerator Attack_Routine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0);
            if (bAttack && animator.GetCurrentAnimatorStateInfo(1).IsName("Upperbody.Attack"))
            {
                if (animator.GetCurrentAnimatorStateInfo(1).normalizedTime >= 0.9f)
                {
                    bAttack = false;
                    animator.SetBool("bAttack", bAttack);
                    break;
                }
            }
        }
    }
}
