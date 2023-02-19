using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _baseRotation = new Vector3(90, 0, 0);
    [SerializeField] private float _basePositionY = 10;

    private void Start()
    {
        transform.eulerAngles = _baseRotation;
    }

    private void Update()
    {
        transform.position = new Vector3(_target.transform.position.x, _basePositionY, _target.transform.position.z);
    }
}

