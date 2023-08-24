using Cinemachine;
using UnityEngine;
using MoreMountains.TopDownEngine;
using EgdFoundation;

public class Player : MonoBehaviour
{
    public int damage = 1;
    public int score = 0;
    private float oldScore;
    private float pointNecessaryForGrownUp = 10f;

    private void Start()
    {
        oldScore = score;
    }

    public void UpdateDamageAndScore(int amountUpdate)
    {
        damage += amountUpdate;
        score = damage;
        GameManager.I.score = score;
        if (score - oldScore >= pointNecessaryForGrownUp)
        {
            PlayerGrownUp();
        }
        SignalBus.I.FireSignal<UpdatePlayerScore>(new UpdatePlayerScore(score));
    }

    private void PlayerGrownUp()
    {
        gameObject.transform.localScale += Vector3.one;
        pointNecessaryForGrownUp += 10;
        oldScore = score;
        SignalBus.I.FireSignal<UpdateFieldOfViewCamera>(new UpdateFieldOfViewCamera());
    }
}