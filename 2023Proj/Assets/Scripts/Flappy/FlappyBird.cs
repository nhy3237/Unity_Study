using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlappyBird : MonoBehaviour
{
    public string sceneToLoad = "03_End";
    public float jumpPower = 5.0f;
    public Text scoreText;

    private Camera mainCamera;
    private float screenBoundX;

    void Start()
    {
        mainCamera = Camera.main;
        screenBoundX = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x;

        int initScore = 0;
        GameManager.Instance.SetScore(initScore);

        scoreText.text = "Score : ";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
        }

        transform.rotation = Quaternion.Euler(0f, 0f, GetComponent<Rigidbody>().velocity.y * 2.5f);

        if (transform.position.x > screenBoundX)
        {
            SwitchScene();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        int curScore = GameManager.Instance.GetScore();
        curScore++;
        GameManager.Instance.SetScore(curScore);
        scoreText.text = $"Score : {curScore}";
    }

    private void OnCollisionEnter(Collision collision)
    {
        SwitchScene();
    }

    private void SwitchScene()
    {
        GameManager.Instance.ChangeScene(sceneToLoad);
        GameManager.Instance.changeScene++;
    }
}
