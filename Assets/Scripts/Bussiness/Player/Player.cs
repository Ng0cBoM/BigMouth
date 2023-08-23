using Cinemachine;
using UnityEngine;
using MoreMountains.TopDownEngine;
using EgdFoundation;

public class Player : MonoBehaviour
{
    public float damage = 1;
    public float score = 0;
    private float oldScore;
    private float pointNecessaryForGrownUp = 10f;

    /*[SerializeField]
    private CinemachineVirtualCamera cmvcam;*/

    private void Start()
    {
        GUIManager.Instance.UpdateScore((int)score);
        oldScore = score;
    }

    public void UpdateDamageAndScore(float amountUpdate)
    {
        damage += amountUpdate;
        score = damage;
        GUIManager.Instance.UpdateScore((int)score);
        if (score - oldScore >= pointNecessaryForGrownUp)
        {
            PlayerGrownUp();
        }
    }

    private void PlayerGrownUp()
    {
        gameObject.transform.localScale += Vector3.one;
        pointNecessaryForGrownUp += 10;
        oldScore = score;
        SignalBus.I.FireSignal<UpdateFieldOfViewCamera>(new UpdateFieldOfViewCamera());
    }
}