using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] objectPrefabs;
    [SerializeField] public float spawnInterval = 1f;
    [SerializeField] public float spawnRangeRatio = 0.8f; 

    private float nextSpawnTime;

    void Update()
    {
        // Membuat objek jatuh dengan interval tertentu
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnObject()
    {
        Camera mainCamera = Camera.main;
        float cameraWidth = mainCamera.aspect * mainCamera.orthographicSize * 2f;
        float spawnRange = cameraWidth * spawnRangeRatio;

        Vector3 spawnPosition = new Vector3(Random.Range(-spawnRange / 2f, spawnRange / 2f), transform.position.y, 0f);

        GameObject selectedPrefab = objectPrefabs[Random.Range(0, objectPrefabs.Length)];

        Instantiate(selectedPrefab, spawnPosition, Quaternion.identity);
    }
}
