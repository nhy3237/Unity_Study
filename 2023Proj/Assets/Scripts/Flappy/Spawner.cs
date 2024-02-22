using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject wallPrefab;
    public float interval = 2.0f;

    IEnumerator Start()
    {
        while (true)
        {
            //transform.position = 
            Instantiate(wallPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(interval);
        }
    }

    void Update()
    {
        
    }
}
