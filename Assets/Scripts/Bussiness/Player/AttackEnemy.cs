using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    private Player player;

    private void Awake()
    {
        player = gameObject.GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (CanAttackEnemy(enemy.health))
            {
                other.gameObject.SetActive(false);
                player.UpdateDamageAndScore(enemy.scoreForPlayerWhenEnemyDead);
            }
        }
    }

    private bool CanAttackEnemy(float healthEnemy)
    {
        return player.damage >= healthEnemy;
    }
}