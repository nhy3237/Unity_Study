using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2D : MonoBehaviour
{
    public GameObject bulletObject;
    public float interval = 2.0f;

    private Rigidbody2D rigidBody;
    new SpriteRenderer renderer;

    float moveSpeed = 500f;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        StartCoroutine(Bullet());
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector3 position = rigidBody.transform.position;
        position = new Vector3(position.x + (-1 * moveSpeed * Time.deltaTime),
                                position.y,
                                position.z); // y에 sin값 넣으면 웨이브 함

        rigidBody.MovePosition(position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.tag == "Player")
        {
            renderer = collision.GetComponent<SpriteRenderer>();
            renderer.material.color = Color.red;

            StartCoroutine(SwitchColor(0.3f));

            int curHP = GameManager.Instance.GetHP();
            curHP -= 20;
            GameManager.Instance.SetHP(curHP);
        }
    }

    IEnumerator Bullet()
    {
        while (true)
        {
            GameObject bullet = Instantiate(bulletObject, transform.position, transform.rotation);
            bullet.transform.parent = transform;
            yield return new WaitForSeconds(interval);
        }
    }

    private IEnumerator SwitchColor(float delay)
    {
        yield return new WaitForSeconds(delay);
        renderer.material.color = Color.white;
    }
}
