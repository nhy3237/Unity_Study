using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSceneTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetMouseButton(0))
        {
            GameManager.Instance.ChangeScene();
        }
       */
        if(Input.GetMouseButton(1))
        {
            if (GameManager.Instance.changeScene == 0)
            {
                GameManager.Instance.ChangeScene("99_End");
                GameManager.Instance.changeScene++;
            }

            if (GameManager.Instance.changeScene == 1)
            {
                GameManager.Instance.ChangeScene("03_Collision");
                GameManager.Instance.changeScene++;
            }
        }
    }

    private void OnGUI() // ���� ���� �� ������ ������� �ʴ´�.
    {
        if (GUI.Button(new Rect(100, 200, 200, 30), "�� ����"))
        {
            if (GameManager.Instance.changeScene == 0)
            {
                GameManager.Instance.ChangeScene("99_End");
                GameManager.Instance.changeScene++;
            }
            else if (GameManager.Instance.changeScene == 1)
            {
                GameManager.Instance.ChangeScene("03_Collision");
                GameManager.Instance.changeScene++;
            }
        }
    }
}
