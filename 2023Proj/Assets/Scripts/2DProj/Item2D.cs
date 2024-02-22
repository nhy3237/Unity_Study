using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item2D : MonoBehaviour
{
    public float moveSpeed = 2000f;

    private Rigidbody2D rigidBody;
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
        position = new Vector3(position.x + (-1 * moveSpeed * Time.deltaTime),
                                position.y,
                                position.z);

        rigidBody.MovePosition(position);
    }

    void Death()
    {
        DestroyImmediate(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            int curScore = GameManager.Instance.GetScore();
            curScore += 20;
            GameManager.Instance.SetScore(curScore);
            Destroy(gameObject, 0.0f);
        }
    }
}
