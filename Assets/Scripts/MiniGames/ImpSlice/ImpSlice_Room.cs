using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpSlice_Room : Room
{
    [SerializeField] private MainCamera _mainCamera;
    [SerializeField] private Transform _cameraPoint;

    protected override void OnEnable()
    {
        base.OnEnable();

        _mainCamera.SetCameraStaticView(_cameraPoint.position, _cameraPoint.eulerAngles);
        Player.gameObject.SetActive(false);
    }
}
