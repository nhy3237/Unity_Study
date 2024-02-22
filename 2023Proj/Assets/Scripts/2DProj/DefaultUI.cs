using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DefaultUI : MonoBehaviour
{
    public GameObject popupObj = null;

    void Start()
    {
        if (popupObj)
            popupObj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void onPopup()
    {
        if (popupObj == null) return;

        if (popupObj.activeSelf)
        {
            Time.timeScale = 1f;
            popupObj.SetActive(false);
        }
        else
        {
            Time.timeScale = 0f;
            popupObj.SetActive(true);
        }
    }
}
