using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private float shakeTime;
    [SerializeField] private float shakeStrong;

    private BlueCastleHealtScript blueCastleHealtScript;

    private void Start()
    {
        blueCastleHealtScript = GameObject.FindGameObjectWithTag("CastleBlue").GetComponent<BlueCastleHealtScript>();

    }
    void Update()
    {
        if (blueCastleHealtScript._blueCastleHealt <= 20) 
        {
            Camera.main.DOShakePosition(shakeTime,shakeStrong);
        }
    }
}
