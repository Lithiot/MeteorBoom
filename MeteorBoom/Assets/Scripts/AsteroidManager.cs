using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour {

    [SerializeField] private GameObject asteroidPrefab;
    [SerializeField] private Transform leftLimit;
    [SerializeField] private Transform rightLimit;
    [SerializeField] private float spawnTimer = 2;

    private int poolSize = 5;
    private float internalTimer;

    private List<GameObject> asteroidPool;

    private void Awake()
    {
        internalTimer = spawnTimer;
    }

    private void Start()
    {
        GenerateAsteroids();
    }

    private void GenerateAsteroids()
    {
        asteroidPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = (GameObject)Instantiate(asteroidPrefab);
            obj.SetActive(false);
            asteroidPool.Add(obj);
        }
    }

    private void Update()
    {
        if (internalTimer <= 0)
        {
            SpawnAsteroid();
            internalTimer = spawnTimer;
        }
        else
            internalTimer -= Time.deltaTime;
    }

    void SpawnAsteroid()
    {
        float xPos = Random.Range(leftLimit.transform.position.x, rightLimit.transform.position.x);
        Vector3 newPosition = new Vector3(xPos, transform.position.y, 0.0f);

        for (int i = 0; i < asteroidPool.Count; i++)
        {
            if (!asteroidPool[i].activeInHierarchy)
            {
                asteroidPool[i].transform.position = newPosition;
                asteroidPool[i].transform.rotation = Quaternion.identity;
                asteroidPool[i].SetActive(true);
                break;
            }
        }
    }
}
