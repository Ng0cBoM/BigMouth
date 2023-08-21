using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyOnPlane : MonoBehaviour
{
    [SerializeField]
    private GameObject[] enemyTypeList;

    [SerializeField]
    private float radiusSpawn = 100f;

    [SerializeField]
    private int quantityEnemySpawn = 20;

    private void Awake()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        foreach (GameObject enemy in enemyTypeList)
        {
            for (int i = 0; i < quantityEnemySpawn; i++)
            {
                float spawnPosX = Random.RandomRange(-radiusSpawn, radiusSpawn);
                float spawnPosY = 0f;
                float spawnPosZ = Random.RandomRange(-radiusSpawn, radiusSpawn);
                Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
                Instantiate(enemy, spawnPosition, enemy.transform.rotation);
            }
        }
    }
}