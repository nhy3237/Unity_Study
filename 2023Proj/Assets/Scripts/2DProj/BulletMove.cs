using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletMove : MonoBehaviour
{
    public float moveSpeed = 500f;

    private Rigidbody2D rigidBody;
    private Animator animator;
    new SpriteRenderer renderer;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
       

        Invoke("Death", 3.0f);
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 position = rigidBody.transform.position;

        if(gameObject.tag == "Bullet")
        {
            position = new Vector3(position.x + (-1 * moveSpeed * Time.deltaTime),
                                    position.y,
                                    position.z);
        }
        else
        {
            position = new Vector3(position.x + (1 * moveSpeed * Time.deltaTime),
                                    position.y,
                                    position.z);
        }
        rigidBody.MovePosition(position);
    }

    void Death()
    {
        DestroyImmediate(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag != "Bullet" && collision.tag == "Enemy")
        {
            int curScore = GameManager.Instance.GetScore();
            curScore++;
            GameManager.Instance.SetScore(curScore);
            Destroy(gameObject, 0.0f);

            animator = collision.GetComponent<Animator>();
            animator.Play("Damage");
            Destroy(collision.gameObject, 0.83f);
        }
        else if(gameObject.tag == "Bullet" && collision.tag == "Player")
        {
            renderer = collision.GetComponent<SpriteRenderer>();
            renderer.material.color = Color.red;
            
            StartCoroutine(SwitchColor(0.1f));

            int curHP = GameManager.Instance.GetHP();
            curHP -= 10;
            GameManager.Instance.SetHP(curHP);
        }
    }

    private IEnumerator SwitchColor(float delay)
    {
        yield return new WaitForSeconds(delay);
        renderer.material.color = Color.white;

        Destroy(gameObject, 0.0f);
    }
}
