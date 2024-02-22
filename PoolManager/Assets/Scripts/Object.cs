using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 3.0f)
        {
            int objectID = int.Parse(gameObject.name.Split('_')[1]);
            PoolManager.Instance.AddObjectIDToQueue(objectID);
            gameObject.SetActive(false);
            Debug.Log("Object with ID : " + objectID);
        }
    }
}