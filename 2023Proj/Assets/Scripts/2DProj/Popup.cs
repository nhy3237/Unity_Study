using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Popup : MonoBehaviour
{
    public Text titleText = null;
    public InputField inputText = null;
    public Toggle toggleBGM = null;
    public GameObject radioGroupObj = null;
    public GameObject playerObj;
    Toggle[] toggleRadio;

    private bool toggleTemp1 = false;
    private bool toggleTemp2 = false;

    void Start()
    {
        titleText.GetComponentInChildren<Text>();
        toggleRadio = radioGroupObj.GetComponentsInChildren<Toggle>();
        toggleTemp1 = toggleRadio[0].isOn;
        toggleTemp2 = toggleRadio[1].isOn;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void onClickOK()
    {
        Debug.Log("onClickOK()");
        gameObject.SetActive(false);
        Time.timeScale = 1f;
        //titleText.text = "OK clicked!!";
    }

    void onClickCancle()
    {
        Debug.Log("onClickCancle()");
        gameObject.SetActive(false);
        Time.timeScale = 1f;

        toggleRadio[0].isOn = toggleTemp1;
        toggleRadio[1].isOn = toggleTemp2;

        if (toggleTemp1)
        {
            playerObj.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            playerObj.transform.localScale = new Vector3(0.8f, 0.8f, 1);
        }
    }

    void onTextChanged()
    {
        //titleText.text = inputText.text;
    }

    void onTextEndEdit()
    {
        //titleText.text = inputText.text;
    }

    public void onToggleBGM()
    {
        if(toggleBGM.isOn)
        {
            Debug.Log("BGM on!!");
        }
        else
        {

            Debug.Log("BGM off!!");
        }
    }

    public void onToggleRadio()
    {
        if (toggleRadio == null) return;
        if (toggleRadio[0].isOn)
        {
            Debug.Log("1번 선택");
            playerObj.transform.localScale = new Vector3(1, 1, 1);
            toggleRadio[0].isOn = true;
            toggleRadio[1].isOn = false;
        }
        else if (toggleRadio[1].isOn)
        {
            Debug.Log("2번 선택");

            playerObj.transform.localScale = new Vector3(0.8f, 0.8f, 1);
            toggleRadio[1].isOn = true;
            toggleRadio[0].isOn = false;
        }        
    }
}


