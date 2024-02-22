using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item3D : MonoBehaviour
{
    public GameObject objItem;

    private int minX = -38;
    private int maxX = 38;
    private int minZ = -23;
    private int maxZ = 23;

    void Start()
    {
        GameObject newItem = Instantiate(objItem, new Vector3 (0, 0, 0), transform.rotation);
        newItem.transform.parent = transform;
    }

    void Update()
    {
        if (!GameManager.Instance.GetHasItem())
        {
            StartCoroutine(SpawnItem(0.5f));
            GameManager.Instance.SetHasItem(true);
        }
    }
    
    private IEnumerator SpawnItem(float delay)
    {
        int randomX = Random.Range(minX, maxX);
        int randomZ = Random.Range(minZ, maxZ);
        Vector3 spawnPosition = new Vector3(randomX, transform.position.y, randomZ);
        yield return new WaitForSeconds(delay);
        GameObject newItem = Instantiate(objItem, spawnPosition, transform.rotation);
        newItem.transform.parent = transform;
    }
}
