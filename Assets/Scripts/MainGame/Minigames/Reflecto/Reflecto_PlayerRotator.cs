using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflecto_PlayerRotator : MonoBehaviour
{
    public void Rotate(Transform player, Vector3 direction, float turnRate)
    {
        player.DORotate(direction, turnRate);
    }
}
