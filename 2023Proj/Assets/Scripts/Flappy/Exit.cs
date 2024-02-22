using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        int curScore = GameManager.Instance.GetScore();
        scoreText.text = $"Total Score : {curScore}";
    }

    public void Click()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
