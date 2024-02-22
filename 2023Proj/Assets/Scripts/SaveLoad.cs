
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

[System.Serializable]
public class SaveInformation
{
    public string name;
    public float posX;
    public float posY;
    public float posZ;
}

public class SaveLoad : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        SaveLoad_Test();
    }

    private void SaveLoad_Test()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (PlayerPrefs.HasKey("ID"))
            {
                string getID = PlayerPrefs.GetString("ID");
                Debug.Log(string.Format("ID : {0} {1}", getID, 2));
            }
            else
            {
                Debug.Log("ID : 없음");
            }
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            string setID = "2023inha";
            PlayerPrefs.SetString("ID", setID);
            Debug.Log("Saved ID : " + setID);
        }

        if(Input.GetKeyDown(KeyCode.C))
        {
            PlayerPrefs.SetInt("Score", 33);
            PlayerPrefs.SetFloat("Exp", 44.4f);

            int getScore = 0;
            if (PlayerPrefs.HasKey("Score"))
                getScore = PlayerPrefs.GetInt("Score");

            float getExp = 0.0f;
            if (PlayerPrefs.HasKey("Exp"))
                getExp = PlayerPrefs.GetFloat("Exp");

            Debug.Log("Score : " + getScore.ToString());
            Debug.Log("Exp : " + getExp.ToString());
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            // Defalut 값 설정
            string getID = PlayerPrefs.GetString("ID2", "NONE");
            int getScore = PlayerPrefs.GetInt("Score2", 100);
            float getExp = PlayerPrefs.GetFloat("Exp2", 100.0f);

            Debug.Log(getScore);
            Debug.Log(getExp);
            Debug.Log(getID);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveBinary();
        }
    }
    void SaveBinary()
    {
        // >> :
        SaveInformation setInfo = new SaveInformation();
        setInfo.name = "2023Inha";
        setInfo.posX = 0.0f;
        setInfo.posY = 4.5f;
        setInfo.posZ = 5.5f;

        Debug.Log(setInfo);
        // << :

        // >> : save
        BinaryFormatter formatter = new BinaryFormatter();
        MemoryStream memStream = new MemoryStream();

        formatter.Serialize(memStream, setInfo);
        byte[] bytes = memStream.GetBuffer();
        string memStr = Convert.ToBase64String(bytes);

        Debug.Log(memStr);
        PlayerPrefs.SetString("SaveInformation", memStr);
        // << : save

        // >> : load
        string getInfo = PlayerPrefs.GetString("SaveInformation");
        Debug.Log(getInfo);

        byte[] getBytes = Convert.FromBase64String(getInfo);
        MemoryStream getMemStream = new MemoryStream(getBytes);

        BinaryFormatter formatter2 = new BinaryFormatter();
        SaveInformation getInformation = (SaveInformation)formatter2.Deserialize(getMemStream);

        Debug.Log(getInformation);
        Debug.Log(getInformation.name);
        Debug.Log(getInformation.posX);
        Debug.Log(getInformation.posY);
        Debug.Log(getInformation.posZ);
        // << :
    }
}
