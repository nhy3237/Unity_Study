using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartClick : MonoBehaviour
{
    public GameObject wall;
    public Text timerText;
    public Text scoreText;

    public void Click()
    {
        transform.parent.gameObject.SetActive(false);
        wall.SetActive(false);

        timerText.gameObject.SetActive(true);
        scoreText.text = "Score : 0";
        scoreText.gameObject.SetActive(true);
    }
}
