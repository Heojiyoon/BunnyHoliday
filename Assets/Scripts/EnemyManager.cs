using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab; // 생성할 적의 프리팹
    public float minY = -100f; // 적의 최소 y축 위치
    public float maxY = 100f; // 적의 최대 y축 위치

    float birthTime = 2;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, birthTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy()
    {
        float randomY = Random.Range(minY, maxY);

        // 적을 생성하고 랜덤한 y축 위치에 배치
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, transform.position.z);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

}
