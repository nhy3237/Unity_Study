using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player3D : MonoBehaviour
{
    public float runSpeed = 5.0f;
    public float rotationSpeed = 360.0f;
    public Text scoreText;
    public GameObject objWeapon;

    CharacterController pcController;
    Vector3 direction;

    Animator animator;

    NavMeshAgent agent = null;

    int curScore = 0;

    public AudioClip audioClip = null;
    private AudioSource audioSource = null;

    void Start()
    {
        pcController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();

        audioClip = Resources.Load(string.Format("Sound/Foot/{0}", "army")) as AudioClip; 
    }

    void Update()
    {
        //CharacterControll_Slerp();
        if (Input.GetMouseButtonDown(0))
        {
            NavMesh_Control();
        }

        Attack();

        curScore = GameManager.Instance.GetScore();
        scoreText.text = $"Score : {curScore}";
    }

    private void NavMesh_Control()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            agent.SetDestination(hit.point);
        }

        if (agent.velocity.magnitude > 0.5f)
            PlaySound(audioClip);
        else
            StopSound();
    }   

    void PlaySound(AudioClip clip)
    {
        if (audioSource.isPlaying) return;

        audioSource.PlayOneShot(clip);
    }

    void StopSound()
    {
        audioSource.Stop();
    }

    private void CharacterControll_Slerp()
    {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (direction.sqrMagnitude > 0.01f)
        {
            Vector3 forward = Vector3.Slerp(transform.forward, direction, rotationSpeed * Time.deltaTime / Vector3.Angle(transform.forward, direction));

            transform.LookAt(transform.position + forward);
        }

        animator.SetFloat("Speed", pcController.velocity.magnitude);
        pcController.Move(direction * runSpeed * Time.deltaTime + Physics.gravity * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")
        {
            curScore = GameManager.Instance.GetScore();
            curScore += 10;
            GameManager.Instance.SetScore(curScore);
            Destroy(other, 0.0f);
            GameManager.Instance.SetHasItem(false);
        }
    }

    private void Attack()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            
            animator.SetTrigger("Attack");
        }

        if(!animator.GetCurrentAnimatorStateInfo(1).IsName("Upperbody.Attack"))
        {
            objWeapon.SetActive(false);
        }
        else
        {
            objWeapon.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            curScore = GameManager.Instance.GetScore();
            curScore += 10;
            GameManager.Instance.SetScore(curScore);
            Destroy(collision.gameObject);
            GameManager.Instance.SetHasItem(false);
        }
    }
}
