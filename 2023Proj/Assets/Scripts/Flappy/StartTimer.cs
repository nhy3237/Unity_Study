using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTimer : MonoBehaviour
{
    public string sceneToLoad = "02_FlappyBird";
    public Text timerText;

    private float countdownDuration = 5.0f;
    private float countdownTimer = 0.0f;

    void Start()
    {
        timerText = GetComponent<Text>();
    }

    void Update()
    {
        if (countdownTimer < countdownDuration)
        {
            countdownTimer += Time.deltaTime;

            if (countdownTimer >= 1.0f)
            {
                countdownTimer -= 1.0f;
                countdownDuration--;
                timerText.text = countdownDuration.ToString();
            }
        }
        else
        {
            timerText.gameObject.SetActive(false);
            SwitchScene();
        }
    }

    private void SwitchScene()
    {
        GameManager.Instance.ChangeScene(sceneToLoad); // ¾À ÀüÈ¯
        GameManager.Instance.changeScene++;
    }
}
