using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner2D : MonoBehaviour
{
    public GameObject enemyObject;
    public GameObject itemObject;
    public float enemyinterval = 7.0f;
    public float iteminterval = 5.0f;
    public int minY = -200;
    public int maxY = 200;

    void Start()
    {
        StartCoroutine(Item());
        StartCoroutine(Enemy());
    }
    IEnumerator Enemy()
    {
        while (true)
        {
            int randomY = Random.Range(minY, maxY);
            Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);
            Instantiate(enemyObject, spawnPosition, transform.rotation);

            yield return new WaitForSeconds(enemyinterval);
        }
    }

    IEnumerator Item()
    {
        while (true)
        {
            int randomY = Random.Range(minY, maxY);
            Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);
            Instantiate(itemObject, spawnPosition, transform.rotation);

            yield return new WaitForSeconds(iteminterval);
        }
    }

    void Update()
    {

    }
}
