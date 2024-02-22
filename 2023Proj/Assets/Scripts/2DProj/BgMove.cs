using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgMove : MonoBehaviour
{
    public float moveSpeed = 500f;
    public GameObject bgObject;

    private Rigidbody2D rigidBody;
    private Camera mainCamera;
    private float screenBoundX;

    private Renderer renderer;
    private float objectWidth;
    private bool hasSpawned = false;

    void Start()
    {
        mainCamera = Camera.main;
        screenBoundX = mainCamera.ScreenToWorldPoint(new Vector3(0, 0, 0)).x;
        renderer = GetComponent<Renderer>();
        objectWidth = renderer.bounds.size.x;
    }

    void Update()
    {
        Move();

        if (!hasSpawned && transform.position.x - (objectWidth / 2) < screenBoundX)
        {
            Vector3 spawnPosition = new Vector3(transform.position.x + objectWidth, transform.position.y, transform.position.z);
            GameObject bgChild = Instantiate(gameObject, spawnPosition, transform.rotation);
            bgChild.transform.parent = bgObject.transform;
            hasSpawned = true;
        }

        if (transform.position.x + (objectWidth / 2) < screenBoundX)
        {
            Death();
            hasSpawned = false;
        }
    }

    void Move()
    {
        Vector3 position = transform.position;
        position = new Vector3(position.x + (-1 * moveSpeed * Time.deltaTime),
                                position.y,
                                position.z);

        transform.position = position;
    }

    void Death()
    {
        DestroyImmediate(this.gameObject);
    }
}
