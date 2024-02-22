using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWall : MonoBehaviour
{
    public float moveSpeed = 10.0f;

    void Start()
    {
        Invoke("Death", 3.0f);    
    }
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
    }

    void Death()
    {
        DestroyImmediate(this.gameObject);
    }
}