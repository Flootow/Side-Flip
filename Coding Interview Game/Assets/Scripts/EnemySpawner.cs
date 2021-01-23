using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public static EnemySpawner Instance { get; private set; }

    [SerializeField] GameObject enemy;
    [SerializeField] Transform spawnOrigin;
    [SerializeField] float distanceMin;
    [SerializeField] float distanceMax;
    int maxCount = 10;
    public int EnemyCount { get; set; } = 0;
    float spawnRate = 1.0f;
    float spawnTimer = 1.0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    void Update()
    {
        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0.0f)
        {
            spawnTimer = spawnRate;
            Debug.Log("Enemy Count: " + EnemyCount.ToString());

            if (EnemyCount < maxCount)
            {
                //Pick a xz heading around the player, go out a valid spawn range distance and try to make a spawn attempt there
                Vector3 spawnTry = Quaternion.Euler(0, Random.Range(0, 360), 0) * new Vector3(Random.Range(distanceMin, distanceMax), 20, 0);
                spawnTry += spawnOrigin.position;
                RaycastHit hitInfo;
                Physics.Raycast(spawnTry, Vector3.down, out hitInfo, 100);
                if (hitInfo.point != null)
                {
                    Instantiate(enemy, hitInfo.point + (1.5f * Vector3.up), new Quaternion());
                }
            }
        }
    }
}
