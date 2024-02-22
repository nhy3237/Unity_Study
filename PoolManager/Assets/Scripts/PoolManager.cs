using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class PoolManager : MonoBehaviour
    {
        public static PoolManager Instance{get; private set;}

        public GameObject objectToPool;

        public int initialPoolSize = 10;
        public int poolSizeIncrement = 5;

        private List<GameObject> objectPool;
        private Queue<int> objectIDsQueue;
        private int nextObjectID = 0;

        public delegate void ObjectReturned(int objectID);
        public static event ObjectReturned OnObjectReturned;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
                return;
            }   

            objectIDsQueue = new Queue<int>();
            
            objectPool = new List<GameObject>();
            for (int i = 0; i < initialPoolSize; i++)
            {
                GameObject newObj = Instantiate(objectToPool);
                int newObjectID = nextObjectID++;
                newObj.name = objectToPool.name + "_" + newObjectID;
                newObj.SetActive(false);
                objectPool.Add(newObj);
                objectIDsQueue.Enqueue(newObjectID);
            }
        }

    public void AddObjectIDToQueue(int objectID)
    {
        objectIDsQueue.Enqueue(objectID);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        if (objectIDsQueue.Count == 0)
        {
            for (int i = 0; i < poolSizeIncrement || objectPool.Count < initialPoolSize + poolSizeIncrement; i++)
            {
                GameObject newObj = Instantiate(objectToPool);
                int newObjectID = nextObjectID++;
                newObj.name = objectToPool.name + "_" + newObjectID;
                newObj.SetActive(false);
                objectPool.Add(newObj);
                objectIDsQueue.Enqueue(newObjectID);
            }
        }

        int objectID = objectIDsQueue.Dequeue();
        GameObject obj = objectPool[objectID];

        float randomX = Random.Range(0f, 19f);
        float randomY = Random.Range(1f, 4f);
        float randomZ = Random.Range(0f, 7f);

        Vector3 spawnPosition = new Vector3(randomX, randomY, randomZ);
        obj.transform.position = spawnPosition;

        obj.SetActive(true);
    }

    public void ReturnObjectToPool(int objectID)
    {
        GameObject obj = objectPool[objectID];
        obj.SetActive(false);
        objectIDsQueue.Enqueue(objectID);

        if (OnObjectReturned != null)
        {
            OnObjectReturned(objectID);
        }
    }
}
