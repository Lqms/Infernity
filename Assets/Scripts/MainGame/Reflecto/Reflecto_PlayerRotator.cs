using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflecto_PlayerRotator : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private Reflecto_PlayerInput _input;
    [SerializeField] private float _turnRate = 0.5f;

    private void OnEnable()
    {
        _input.RotateKeyPressed += OnRotateKeyPressed;
    }

    private void OnDisable()
    {
        _input.RotateKeyPressed -= OnRotateKeyPressed;
    }

    private void OnRotateKeyPressed(Vector3 direction)
    {
        _player.DORotate(direction, _turnRate);
    }
}
