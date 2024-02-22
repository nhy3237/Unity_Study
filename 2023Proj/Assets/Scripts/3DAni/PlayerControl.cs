using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Animation spartanKing;
    public AnimationClip IDLE;
    public AnimationClip RUN;
    public AnimationClip ATTACK;

    CharacterController pcControl;
    public float runSpeed = 10.0f;
    Vector3 velocity;

    public float rotationSpeed = 720.0f;

    public GameObject objSword = null;

    void Start()
    {
        spartanKing = gameObject.GetComponentInChildren<Animation>();
        pcControl = gameObject.GetComponent<CharacterController>();
        objSword.SetActive(false);
    }

    void Update()
    {
        AnimationPlay_4();
        //CharacterController_Slerp();
    }

    private void CharacterController_Slerp()
    {
        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"),
                               0, Input.GetAxis("Vertical"));
        
        if (direction.sqrMagnitude > 0.01f)
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.CrossFade(RUN.name, 0.3f);

            Vector3 forward = Vector3.Slerp(transform.forward, direction,
                                            rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction));
            
            transform.LookAt(transform.position + forward);
        }
        else
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.CrossFade(IDLE.name, 0.3f);
        }

        pcControl.Move(direction * runSpeed * Time.deltaTime + Physics.gravity * Time.deltaTime);
        //pcControl.SimpleMove(velocity);
    }

    private void CharacterController()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"),
                               0, Input.GetAxis("Vertical"));
        velocity *= runSpeed;
        if(velocity.magnitude > 0.5)
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.CrossFade(RUN.name, 0.3f);
            transform.LookAt(transform.position + velocity);
        }
        else
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.CrossFade(IDLE.name, 0.3f);
        }

        //pcControl.Move(velocity * Time.deltaTime + Physics.gravity * Time.deltaTime);
        pcControl.SimpleMove(velocity);

    }

    private void AnimationPlay_4()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine("AttackToIdle2");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.CrossFade(RUN.name, 0.6f);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.CrossFade(IDLE.name, 0.6f);
        }
    }

    IEnumerator AttackToIdle2()
    {
        //if (spartanKing.IsPlaying("attack") == true) yield break;
        if (spartanKing[ATTACK.name].enabled == true) yield break;

        objSword.SetActive(true);

        spartanKing.wrapMode = WrapMode.Once;
        spartanKing.CrossFade(ATTACK.name, 0.3f);
        float delayTime = spartanKing.GetClip(ATTACK.name).length - 0.3f;
        yield return new WaitForSeconds(delayTime);

        spartanKing.wrapMode = WrapMode.Loop;
        spartanKing.CrossFade(IDLE.name, 0.3f);

        objSword.SetActive(false);
    }

    private void AnimationPlay_3()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine("AttackToIdle");
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.CrossFade("run", 0.6f);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.CrossFade("idle", 0.6f);
        }
    }

    IEnumerator AttackToIdle()
    {
        //if (spartanKing.IsPlaying("attack") == true) yield break;
        if (spartanKing["attack"].enabled == true) yield break;

        spartanKing.wrapMode = WrapMode.Once;
        spartanKing.CrossFade("attack", 0.3f);
        float delayTime = spartanKing.GetClip("attack").length - 0.3f;
        yield return new WaitForSeconds(delayTime);

        spartanKing.wrapMode = WrapMode.Loop;
        spartanKing.CrossFade("idle", 0.3f);
    }

    private void AnimationPlay_2()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            spartanKing.wrapMode = WrapMode.Once;
            spartanKing.CrossFade("attack", 0.6f);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.CrossFade("run", 0.6f);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            spartanKing.wrapMode = WrapMode.Loop;
            spartanKing.CrossFade("idle", 0.6f);
        }
    }

    private void AnimationPlay_1()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
            spartanKing.Play("idle");
        if (Input.GetKeyDown(KeyCode.Alpha1))
            spartanKing.Play("walk");
        if (Input.GetKeyDown(KeyCode.Alpha2))
            spartanKing.Play("run");
        if (Input.GetKeyDown(KeyCode.Alpha3))
            spartanKing.Play("charge");
        if (Input.GetKeyDown(KeyCode.Alpha4))
            spartanKing.Play("idlebattle");
        if (Input.GetKeyDown(KeyCode.Alpha5))
            spartanKing.Play("resist");
        if (Input.GetKeyDown(KeyCode.Alpha6))
            spartanKing.Play("victory");
        if (Input.GetKeyDown(KeyCode.Alpha7))
            spartanKing.Play("salute");
        if (Input.GetKeyDown(KeyCode.Alpha8))
            spartanKing.Play("die");
        if (Input.GetKeyDown(KeyCode.Alpha9))
            spartanKing.Play("diehard");
    }
}
