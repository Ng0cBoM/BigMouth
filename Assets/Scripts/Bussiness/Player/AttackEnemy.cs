using MoreMountains.Feedbacks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    private Player player;
    public MMFeedbacks attackFeedback;

    private void Awake()
    {
        player = gameObject.GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>())
        {
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (CanAttackEnemy(enemy.health))
            {
                HandleFeedbacks();
                other.gameObject.SetActive(false);
                player.UpdateDamageAndScore(enemy.scoreForPlayerWhenEnemyDead);
            }
        }
    }

    private void HandleFeedbacks()
    {
        attackFeedback?.PlayFeedbacks();
    }

    private bool CanAttackEnemy(float healthEnemy)
    {
        return player.damage >= healthEnemy;
    }
}