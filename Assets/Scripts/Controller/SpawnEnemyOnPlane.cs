using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyOnPlane : MonoBehaviour
{
    [SerializeField]
    private EnemyType[] enemyTypeList;

    [SerializeField]
    private float radiusSpawn = 100f;

    [SerializeField]
    private Transform enemyPool;

    [System.Serializable]
    private struct EnemyType
    {
        public GameObject enemyPrefab;
        public int quantityEnemySpawn;
    }

    private void Awake()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        foreach (EnemyType enemy in enemyTypeList)
        {
            for (int i = 0; i < enemy.quantityEnemySpawn; i++)
            {
                float spawnPosX = Random.RandomRange(-radiusSpawn, radiusSpawn);
                float spawnPosY = 0f;
                float spawnPosZ = Random.RandomRange(-radiusSpawn, radiusSpawn);
                Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
                GameObject newEnemy = Instantiate(enemy.enemyPrefab, spawnPosition, enemy.enemyPrefab.transform.rotation);
                newEnemy.transform.parent = enemyPool;
            }
        }
    }
}