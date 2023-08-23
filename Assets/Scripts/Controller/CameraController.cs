using Cinemachine;
using EgdFoundation;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    private CinemachineVirtualCamera cmvcam;
    private float rangeIncrease = 5f;

    private void Awake()
    {
        cmvcam = gameObject.GetComponent<CinemachineVirtualCamera>();
        SignalBus.I.Register<UpdateFieldOfViewCamera>(IncreaseFieldOfView);
        cmvcam.LookAt = player.transform;
        cmvcam.Follow = player.transform;
    }

    public void IncreaseFieldOfView(UpdateFieldOfViewCamera signal)
    {
        if (cmvcam != null)
        {
            cmvcam.m_Lens.FieldOfView += rangeIncrease;
        }
        else
        {
            Debug.LogWarning("Cinemachine Virtual Camera is not assigned!");
        }
    }

    private void OnDestroy()
    {
        SignalBus.I.Unregister<UpdateFieldOfViewCamera>(IncreaseFieldOfView);
    }
}