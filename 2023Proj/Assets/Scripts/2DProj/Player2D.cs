using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2D : MonoBehaviour
{
    public GameObject bulletObject;
    public Text scoreText;
    public Image imgHPBar = null;
    public GameObject gameOverPanel;

    private Rigidbody2D rigidBody;
    float maxSpeed = 1000f;
    new SpriteRenderer renderer;

    int curScore = 0;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        //Flip_2D(x);
        Move_2(y);
        ShowHPBar();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletObject, transform.position, transform.rotation);
        }

        curScore = GameManager.Instance.GetScore();
        scoreText.text = $"Score : {curScore}";
    }

    void Flip_2D(float x)
    {
        if(Mathf.Abs(x) > 0)
        {
            if (x >= 0)
                renderer.flipX = false;
            else
                renderer.flipX = true;
        }

        //renderer.material.SetColor("_Color", new Color(1f * Mathf.Sin(Time.time), 1f - Mathf.Sin(Time.time), 1f));
    }

    void Move_2(float y)
    { 
        Vector3 position = rigidBody.transform.position;
        position = new Vector3(position.x,
                                position.y + (y * maxSpeed * Time.deltaTime),
                                position.z);
        
        if (position.y < -280) position.y += 3;
        else if (position.y > 280) position.y -= 3;

        rigidBody.MovePosition(position);
    }

    void Move_1(float x, float y)
    {
        rigidBody.AddForce(new Vector2(x * maxSpeed * Time.deltaTime,
                                  y * maxSpeed * Time.deltaTime));
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            Destroy(collision.gameObject, 0.5f);
        }
    }*/

    void ShowHPBar()
    {
        int curHP = GameManager.Instance.GetHP();
        imgHPBar.fillAmount = (float)curHP / (float)100;

        if(curHP < 0)
        {
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
        }
    }
}
